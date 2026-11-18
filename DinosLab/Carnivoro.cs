using System.Configuration;

namespace DinosLab
{
    public class Carnivoro : Dinosaurio
    {
        public override void Alimentar()
        {
            Energia += 20;

            if (Energia > 100)
                Energia = 100;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Depredador especializado en cazar";
        }

        public override int Atacar()
        {
            return Fuerza += 10;
        }
    }
}