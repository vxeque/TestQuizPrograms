
namespace TestQuiz.Models
{
    public class QuizDataModels

    {
        // objeto la clase preguntas
        Preguntas preguntas = new Preguntas();
        
        // propiedad para guardar el indece de la pregunta actual
        private int indexPreguntaActual = 0;
        public int IndexPreguntaActual
        {
            get
            {
                return indexPreguntaActual;
            }
            set
            {
                indexPreguntaActual = value;
            }
        }

        // Método para pasar a la siguiente pregunta
        public int NextQuestion()
        {
            // Verifica si el índice de la pregunta actual es mayor o igual al número total de preguntas menos 1
            if (indexPreguntaActual >= preguntas.Getpreguntas.Count - 1)
            {
                // Si es así, se establece el índice de la pregunta actual al principio para permitir la navegación circular de las preguntas
                indexPreguntaActual = 0;
                return indexPreguntaActual;
            }

            // retorna un valor entero que significa el indice de la pregunta en el diccionario de preguntas
            return ++indexPreguntaActual;
        }

        // Método que maneja el evento de ir a la pregunta anterior
        public int PreviousQuestion()
        {
            // Verifica si el índice de la pregunta actual es menor o igual a cero
            if (indexPreguntaActual <= 0)
            {
                // Si es así, establece el índice de la pregunta actual al final de la lista de preguntas
                // para permitir la navegación circular de las preguntas
                indexPreguntaActual = preguntas.Getpreguntas.Count - 1;
            }

            // Disminuye el índice de la pregunta actual para pasar a la pregunta anterior
            return --indexPreguntaActual;

        }

        // propiedad para obtener el key de la pregunta actual
        private string? _currentQuestion;
        public string? showCurrentQuestion
        {
            get { return _currentQuestion; }
            set { _currentQuestion = value; }
        }

        // propiedad para conocer la respuesta de true o false
        // de la pregunta actual
        private bool? _boolQuestion;
        public bool? boolQuestion
        {
            get => _boolQuestion;
            set => _boolQuestion = value;
        }

        // Método para mostrar la pregunta actual en la interfaz de usuario
        public string ShowCurrentQuestion(int index)
        {
            // Se obtiene la pregunta actual del diccionario utilizando el índice almacenado en indexPreguntaActual
            var currentQuestion = preguntas.Getpreguntas.ElementAt(index);

            showCurrentQuestion = currentQuestion.Key;
            boolQuestion = currentQuestion.Value;
            return showCurrentQuestion;
        }

        public string verify(bool falseoftrueanswer)
        {

            if (boolQuestion == falseoftrueanswer)
            {
                return "¡Correcto!";
            }
            else
            {
                return "¡Incorrecto!";
            }
        }

    }
}
