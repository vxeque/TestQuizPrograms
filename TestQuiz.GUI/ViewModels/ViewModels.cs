using TestQuiz.Models;
using System.Windows.Input;
using System.ComponentModel;

namespace TestQuiz.GUI.ViewModels
{
    public class ViewModels : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Propiedad para almacenar el número total de preguntas respondidas correctamente
        private int _totalCorrectQuestions;
        public int TotalCorrectQuestions
        {
            get { return _totalCorrectQuestions; }
            set
            {
                _totalCorrectQuestions += value;
                OnPropertyChanged(nameof(TotalCorrectQuestions));
            }
        }

        // Propiedad para almacenar el número total de preguntas respondidas
        private int _totalQuestionsAnswered;
        public int TotalQuestionsAnswered
        {
            get { return _totalQuestionsAnswered; }
            set
            {
                _totalQuestionsAnswered += value;
                OnPropertyChanged(nameof(TotalQuestionsAnswered));
            }
        }

        private QuizDataModels QuizDataModels { get; set; }

        public ViewModels()
        {
            QuizDataModels = new QuizDataModels();
            ButtonNextQuestion = new Command(ExecuteNextQuestion);
            ButtonPreviousQuestion = new Command(ExecutePreviousQuestion);
            ButtonQuestionVerifyFalse = new Command(VerifyOfFalse);
            ButtonQuestionVerifyTrue = new Command(VerifyOfTrue);
        }

        // comando para botones
        public ICommand ButtonNextQuestion { get; private set; }
        public ICommand ButtonPreviousQuestion { get; private set; }

        private void ExecuteNextQuestion()
        {
            // Obtiene el índice de la próxima pregunta del modelo de datos
            int indexQuestion = QuizDataModels.NextQuestion();
            // Actualiza la propiedad ShowQuestions con la pregunta actual según el índice obtenido
            ShowQuestions = QuizDataModels.ShowCurrentQuestion(indexQuestion);
            // Limpia el mensaje de verificación de la respuesta del usuario para la nueva pregunta
            VerifyQuestionOfUser = "";
            // si se ejecuta el boton para la pregunta anterior se asigna false ya que no estara contestada
            QuestionVerified = false;
        }

        private void ExecutePreviousQuestion()
        {
            // Obtiene el índice de la pregunta anterior del modelo de datos
            int indexQuestion = QuizDataModels.PreviousQuestion();

            // Actualiza la propiedad ShowQuestions con la pregunta actual según el índice obtenido
            ShowQuestions = QuizDataModels?.ShowCurrentQuestion(indexQuestion);

            // Limpia el mensaje de verificación de la respuesta del usuario para la nueva pregunta
            VerifyQuestionOfUser = "";

            // si se ejecuta el boton para la pregunta anterior se asigna false ya que no estara contestada
            QuestionVerified = false;
        }

        private string? _questions = "Test Questions";
        public string? ShowQuestions
        {
            get
            {
                return _questions;
            }
            set
            {
                _questions = value;
                // Notifica a la interfaz de usuario sobre el cambio en la propiedad ShowQuestions
                OnPropertyChanged(nameof(ShowQuestions));
            }
        }

        // comando para el boton de false
        public ICommand ButtonQuestionVerifyFalse { get; private set; }
        // comando para el boton de true
        public ICommand ButtonQuestionVerifyTrue { get; private set; }

        // propiedad para obtener el resultado de pregunta del usuario
        private string _resultQuestionOfUser;
        public string VerifyQuestionOfUser
        {
            get { return _resultQuestionOfUser; }
            set
            {
                _resultQuestionOfUser = value;
                // Notifica a la interfaz de usuario sobre el cambio en la propiedad VerifyQuestionOfUser
                OnPropertyChanged(nameof(VerifyQuestionOfUser));
            }
        }


        // propiedad para verificar que la pregunta actual fue contestada
        private bool QuestionVerified { get; set; }

        // Función que verifica una pregunta booleana falsa
        private void VerifyOfFalse()
        {
            // Verifica si la pregunta aún no ha sido verificada
            if (!QuestionVerified)
            {
                // Incrementa el contador de preguntas respondidas
                TotalQuestionsAnswered = 1;

                // Verifica si la pregunta del modelo es falsa
                if (QuizDataModels.boolQuestion == false)
                {
                    // Verifica la respuesta del usuario utilizando el método 'verify(false)' del objeto QuizDataModels
                    VerifyQuestionOfUser = QuizDataModels.verify(false);

                    // Si la respuesta es correcta, incrementa el contador de preguntas correctas
                    TotalCorrectQuestions = 1;
                }
                else
                {
                    VerifyQuestionOfUser = QuizDataModels.verify(true);
                }
            }

            // Marca la pregunta como verificada, independientemente del resultado de la verificación
            QuestionVerified = true;
        }


        // Función que verifica una pregunta booleana verdadera
        private void VerifyOfTrue()
        {
            // Verifica si la pregunta aún no ha sido verificada
            if (!QuestionVerified)
            {
                // Incrementa el contador de preguntas respondidas
                TotalQuestionsAnswered = 1;

                // Verifica si la pregunta del modelo es verdadera
                if (QuizDataModels.boolQuestion == true)
                {
                    // Verifica la respuesta del usuario utilizando el método 'verify(true)' del objeto QuizDataModels
                    VerifyQuestionOfUser = QuizDataModels.verify(true);

                    // Si la respuesta es correcta, incrementa el contador de preguntas correctas
                    TotalCorrectQuestions = 1;
                }
                else
                {
                    VerifyQuestionOfUser = QuizDataModels.verify(true);
                }
            }

            // Marca la pregunta como verificada, independientemente del resultado de la verificación
            QuestionVerified = true;
        }

    }
}