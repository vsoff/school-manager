using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemCard.Shell;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories;

namespace SchoolManagerDeskop.Common.Services
{
    public class StudentCardEventArgs : EventArgs
    {
        public Student Student { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }

    public interface ICardStudentAuthoriser : IDisposable
    {
        event EventHandler<StudentCardEventArgs> CardInserted;
        event EventHandler<EventArgs> CardRemoved;
        bool BindCard(int studentId);
        bool UnbindCard();
    }

    public class CardStudentAuthoriser : ICardStudentAuthoriser
    {
        private const int UnbindStudentId = 0;

        private readonly ISmartReaderListener _smartReaderListener;
        private readonly IStudentsRepository _studentsRepository;

        public CardStudentAuthoriser(
            ISmartReaderListener smartReaderListener,
            IStudentsRepository studentsRepository)
        {
            _smartReaderListener = smartReaderListener ?? throw new ArgumentNullException(nameof(smartReaderListener));
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));

            _smartReaderListener.CardInserted += OnCardInserted;
            _smartReaderListener.CardRemoved += OnCardRemoved;
        }

        private void OnCardRemoved(object sender, EventArgs e) => CardRemoved?.Invoke(this, e);

        private void OnCardInserted(object sender, CardInsertedEventArgs e)
        {
            Student student = null;
            if (e.Value.HasValue)
                student = _studentsRepository.Get(e.Value.Value);

            CardInserted?.Invoke(this, new StudentCardEventArgs
            {
                Student = student,
                IsSuccess = student != null,
                ErrorMessage = e.Value.HasValue
                    ? (e.Value == UnbindStudentId
                        ? "Карта ни к кому не привязана"
                        : $"Ученик с ID = {e.Value} не найден")
                    : "Ошибка чтения карты, попробуйте снова"
            });
        }

        public bool BindCard(int studentId) => _smartReaderListener.WriteValue(studentId);

        public bool UnbindCard() => _smartReaderListener.WriteValue(UnbindStudentId);

        public event EventHandler<StudentCardEventArgs> CardInserted;
        public event EventHandler<EventArgs> CardRemoved;

        public void Dispose()
        {
            _smartReaderListener.CardInserted -= OnCardInserted;
            _smartReaderListener.CardRemoved -= OnCardRemoved;
            _smartReaderListener?.Dispose();
        }
    }
}