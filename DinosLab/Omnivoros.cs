namespace DinosLab
{
    public class Omnivoros : Dinosaurio
    {
        public override void Alimentar()
        {
            Energia += 25;

            if (Energia > 100)
                Energia = 100;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Puede aprovechar carne y vegetales";
        }

        public override void Entrenar()
        {
            Experiencia += 15;
            Velocidad += 2;
        }
    }
}