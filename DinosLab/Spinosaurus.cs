namespace DinosLab
{
    public class Spinosaurus : Carnivoro
    {
        public override int Atacar()
        {
            return Fuerza + 20;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Emboscada submarina: ataque especializado en el agua";
        }

        public override void Entrenar()
        {
            Fuerza += 3;
            Defensa += 3;
            Experiencia += 10;
        }

        public override void RecuperarEnergia()
        {
            Energia += 30;

            if (Energia > 100)
                Energia = 100;
        }
    }
}