namespace DinosLab
{
    public class Herbivoros : Dinosaurio
    {
        public override void Alimentar()
        {
            Energia += 20;

            if (Energia > 100)
                Energia = 100;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Especialista en defensa y resistencia";
        }

        public override int Defender()
        {
            return Defensa += 10;
        }
    }
}