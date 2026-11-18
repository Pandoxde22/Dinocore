namespace DinosLab
{
    public class Velociraptor : Carnivoro
    {
        public override int Atacar()
        {
            return Fuerza + Velocidad + 10;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Ataque relámpago: aprovecha su gran velocidad";
        }

        public override void Entrenar()
        {
            Velocidad += 5;
            Experiencia += 10;
        }

        public override int Defender()
        {
            return Defensa + 10;
        }
    }
}