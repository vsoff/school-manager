using SchoolManagerDeskop.Common.Classes;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagerDeskop.Common.Services
{

    /// <summary>
    /// Сервис, позволяющий управлять регистрациями учеников на занятия (сессии).
    /// </summary>
    public interface IStudentRegistrationService
    {
        /// <summary>
        /// Возвращает информацию о регистрации ученика на занятие и её возможности в указанное время.
        /// </summary>
        RegistrationInfoResponse GetRegistrationInfo(long studentId, long sessionId, DateTime checkDateTime);

        /// <summary>
        /// Регистрирует ученика на занятие.
        /// </summary>
        void RegisterStudentInSession(long studentId, long sessionId);

        /// <summary>
        /// Отменяет регистрирацию ученика на занятие.
        /// </summary>
        void UnregisterStudentInSession(long studentId, long sessionId);
    }

    public class StudentRegistrationService : IStudentRegistrationService
    {
        /// <summary>
        /// Максимально возможная задержка регистрации на занятие, после его начала.
        /// </summary>
        private readonly TimeSpan _maxRegistrationDelay = TimeSpan.FromMinutes(15);

        /// <summary>
        /// Максимально возможная задержка регистрации на занятие, после его начала.
        /// </summary>
        private readonly TimeSpan _maxPreregistrationPeriod = TimeSpan.FromDays(7);

        private readonly ISubscriptionsRepository _subscriptionsRepository;
        private readonly ISessionsRepository _sessionsRepository;
        private readonly IStudentsRepository _studentsRepository;

        public StudentRegistrationService(
            ISubscriptionsRepository subscriptionsRepository,
            ISessionsRepository sessionsRepository,
            IStudentsRepository studentsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository ?? throw new ArgumentNullException(nameof(subscriptionsRepository));
            _sessionsRepository = sessionsRepository ?? throw new ArgumentNullException(nameof(sessionsRepository));
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
        }

        public RegistrationInfoResponse GetRegistrationInfo(long studentId, long sessionId, DateTime checkDateTime)
        {
            Session session = _sessionsRepository.Get(sessionId);
            DateTime sessionDateTime = session.Date.Add(session.Time);

            // Если ученик уже зарегистрирован, то обрабатываем по особенному.
            bool isAlreadyRegistered = session.Students.FirstOrDefault(x => x.Id == studentId) != null;

            if (!isAlreadyRegistered)
            {
                // Проверяем временные ограничения.
                if (checkDateTime < sessionDateTime.Add(_maxRegistrationDelay))
                    return GetBadRegisterResponse($"Занятие началось больше {_maxRegistrationDelay.TotalMinutes} минут назад");

                if (checkDateTime.Date < sessionDateTime.Date.Add(_maxPreregistrationPeriod))
                    return GetBadRegisterResponse($"Нельзя записаться на занятие раньше чем за {_maxPreregistrationPeriod.TotalDays} дней");
            }

            // Разделяем лимитированные и безлимитные абонементы, сортируем по дате окончания их действия.
            // (то, что раньше заканчивается, должно использоваться в первом приоритете)
            Subscription[] allSubscriptions = _subscriptionsRepository.GetAllActiveSubscriptionsInTime(studentId, sessionDateTime);
            Subscription[] limitedSubscriptions = allSubscriptions
                .Where(x => x.GroupId.HasValue && x.GroupId == session.GroupId && !x.HasUnlimitedGroup)
                .OrderBy(x => x.DateEnd)
                .ToArray();
            Subscription[] unlimitedSubscriptions = allSubscriptions
                .Where(x => !x.GroupId.HasValue && x.HasUnlimitedGroup)
                .OrderBy(x => x.DateEnd)
                .ToArray();

            // Проверяем подписки.
            if (!isAlreadyRegistered && limitedSubscriptions.Length == 0 && unlimitedSubscriptions.Length == 0)
                return GetBadRegisterResponse("У ученика нету абонементов для данной группы");

            Subscription selectedSubscription = null;

            // Пытаемся найти лимитированный абонемент.
            if (limitedSubscriptions.Length != 0)
                selectedSubscription = limitedSubscriptions.FirstOrDefault(x => x.SubHoursLeft > 0);

            // Если лимитированного нету, пытаемся найти безлимитный.
            if (selectedSubscription == null)
                selectedSubscription = unlimitedSubscriptions.FirstOrDefault(x => x.SubHoursLeft > 0);

            if (!isAlreadyRegistered && selectedSubscription == null)
                return GetBadRegisterResponse("У всех имеющихся абонементов ученика закончились часы");

            if (isAlreadyRegistered)
                return new RegistrationInfoResponse
                {
                    IsAlreadyRegistered = true,
                    IsCanUnregister = checkDateTime < sessionDateTime.Add(_maxRegistrationDelay),
                    IsRegistrationPossible = false,
                    WarningMessage = string.Empty,
                    IsSubscriptionFounded = selectedSubscription != null,
                    Subscription = selectedSubscription
                };

            return new RegistrationInfoResponse
            {
                IsAlreadyRegistered = false,
                IsCanUnregister = false,
                IsRegistrationPossible = true,
                WarningMessage = string.Empty,
                IsSubscriptionFounded = true,
                Subscription = selectedSubscription
            };
        }

        public void RegisterStudentInSession(long studentId, long sessionId) => _sessionsRepository.RegisterStudentInSession(studentId, sessionId);

        public void UnregisterStudentInSession(long studentId, long sessionId) => _sessionsRepository.UnregisterStudentInSession(studentId, sessionId);

        private RegistrationInfoResponse GetBadRegisterResponse(string message)
        {
            return new RegistrationInfoResponse
            {
                IsAlreadyRegistered = false,
                IsCanUnregister = false,
                IsRegistrationPossible = false,
                WarningMessage = message,
                IsSubscriptionFounded = false,
                Subscription = null
            };
        }
    }
}
