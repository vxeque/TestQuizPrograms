namespace TestQuiz.Models
{
    public class Preguntas
    {
        private Dictionary<string, bool> _preguntas;
        public Preguntas()
        {
            _preguntas = new Dictionary<string, bool>();

            // 15 preguntas para el cuestionario 
            _preguntas.Add("¿Mexico es un pais independiente?", true);
            _preguntas.Add("¿Estados Unidos es la potencia economica?", true);
            _preguntas.Add("¿China es la tercera potencia mundial?", false);
            _preguntas.Add("¿Mexico importa petroleo?", false);
            _preguntas.Add("¿Mexico es un pais cultural?", true);
            _preguntas.Add("¿El Muro de Berlín dividió la ciudad de Berlín en dos partes, separando Alemania Occidental de Alemania Oriental?", true);
            _preguntas.Add("¿El Brexit fue el proceso mediante el cual España salió de la Unión Europea?",false);
            _preguntas.Add("¿La Unión Soviética fue una potencia aliada de Estados Unidos durante la Segunda Guerra Mundial?", false);
            _preguntas.Add("¿La OTAN es una alianza militar formada exclusivamente por países asiáticos? ", false);
            _preguntas.Add("¿El Tratado de Versalles fue uno de los acuerdos que puso fin a la Primera Guerra Mundial?", true);
            _preguntas.Add("¿El conflicto entre Israel y Palestina se centra en disputas territoriales y políticas?", true);
            _preguntas.Add("¿La Ruta de la Seda fue una red histórica de rutas comerciales entre Asia, Europa y África?", true);
            _preguntas.Add("¿El Estrecho de Ormuz es una vía marítima estratégica entre el Golfo Pérsico y el Mar de Omán?", true);
            _preguntas.Add("¿La Guerra Fría fue un periodo de tensión política y militar entre Estados Unidos y la Unión Soviética?", true);
            _preguntas.Add("¿La ONU tiene su sede principal en la ciudad de Ginebra, Suiza?", false);
        }

        public Dictionary<string, bool> Getpreguntas
        {
            get { return _preguntas; }
        }
    }
}
