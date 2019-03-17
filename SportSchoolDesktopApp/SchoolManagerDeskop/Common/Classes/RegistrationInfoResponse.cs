using SchoolManagerDeskop.Core.Dao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Classes
{
    /// <summary>
    /// Ответ, содержащий информацию о регистрации ученика в сессии и её возможности.
    /// </summary>
    public class RegistrationInfoResponse
    {
        /// <summary>
        /// Возвращает значение, указывающее, зарегистрирован ли уже ученик в сессии.
        /// </summary>
        public bool IsAlreadyRegistered { get; set; }

        /// <summary>
        /// Возвращает значение, указывающее, можно ли отменить регистрацию.
        /// </summary>
        public bool IsCanUnregister { get; set; }

        /// <summary>
        /// Возвращает значение, указывающее, возможна ли регистрация для данного ученика.
        /// </summary>
        public bool IsRegistrationPossible { get; set; }

        /// <summary>
        /// Причина, по которой ученик не может быть зарегистрирован.
        /// </summary>
        public string WarningMessage { get; set; }

        /// <summary>
        /// Возвращает значение, указывающее, был ли найден абонемент.
        /// </summary>
        public bool IsSubscriptionFounded { get; set; }

        /// <summary>
        /// Объект абонемента.
        /// </summary>
        public Subscription Subscription { get; set; }
    }
}
