namespace DinosLab
{
    public class Rex : Carnivoro
    {
        public override int Atacar()
        {
            return Fuerza + 25;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Mordida devastadora: aumenta el daño de ataque";
        }

        public override void Entrenar()
        {
            Fuerza += 5;
            Experiencia += 10;
        }
    }
}