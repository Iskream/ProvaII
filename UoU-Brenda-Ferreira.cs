using System;
namespace projeto00
{
    class Batalha
    {
        public static void Main(string[] args)
        {
            HeroiAlianca alianca = new HeroiAlianca("Brownie", 80);
            HeroiHorda horda = new HeroiHorda("Sorvete", 80);
            bool game = true;
            while (game == true)
            {
                // Ataque Alianca
                alianca.AumentarUT(3);
                
                string ataque = string.Empty;
                Console.WriteLine("Ataque da Aliança! O herói " + alianca.GetNome() + " tem " + alianca.ExibirUT() + " UT ! Escolha o ataque: ");
                Console.WriteLine("Digite M para atacar com Magia, digite A para usar arma ou D para acumular energia:");
                ataque = Console.ReadLine().ToUpper();

                if (ataque == "M") {

                    alianca.LancarMagia();
                        if (alianca.ExibirUT() < 4) {
                            Console.WriteLine("...mas o ataque falhou! Não há UT suficiente!");
                        } else {
                    alianca.ReduzirUT(4); // reduz utheroialianca
                    horda.ReduzirVida(20);
                    }
                    
                } else if (ataque == "A")
                {
                    alianca.AtacarComArma();
                    if (alianca.ExibirUT() < 12) {
                            Console.WriteLine("...mas o ataque falhou! Não há UT suficiente!");
                    } else {
                    alianca.ReduzirUT(12); // reduz utheroialianca
                    horda.ReduzirVida(30);
                    }
                    
                } else if (ataque == "D")
                {
                    alianca.AcumularUT();
                }else
                {
                    Console.WriteLine("Ataque inválido! O herói " + alianca.GetNome() + " não atacou nesse turno.");
                }
                Console.WriteLine("========================================================");
                Console.WriteLine();
                Console.WriteLine("Vida restante do herói " + horda.GetNome() + " da Horda: " + horda.GetPtsVida());

                if (horda.GetPtsVida() <= 0)
                {
                    Console.WriteLine("O heroi " + alianca.GetNome() + " da Alianca venceu! e sobrou " + alianca.GetPtsVida() + " de vida!");
                    Console.WriteLine("Game Over!");
                    break;
                }
                
                // Ataque Horda
                horda.AumentarUT(3);

                Console.WriteLine("Ataque da Horda! O herói " + horda.GetNome() + " tem " + horda.ExibirUT() + " UT ! Escolha o ataque: ");
                Console.WriteLine("Digite M para atacar com Magia, digite A para usar arma ou D para acumular energia:");
                Console.WriteLine();
                Console.WriteLine("========================================================");
                ataque = Console.ReadLine().ToUpper();

                if (ataque == "M") {

                    horda.LancarMagia();
                        if (horda.ExibirUT() < 6) {
                            Console.WriteLine("...mas o ataque falhou! Não há UT suficiente!");
                        } else {
                    horda.ReduzirUT(6); // reduz utheroihorda
                    alianca.ReduzirVida(30);
                        }

                } else if (ataque == "A")
                {
                    horda.AtacarComArma();
                    if (horda.ExibirUT() < 14) {
                            Console.WriteLine("...mas o ataque falhou! Não há UT suficiente!");
                        } else {
                    horda.ReduzirUT(14); // reduz utheroihorda
                    alianca.ReduzirVida(20);
                        }
                } else if (ataque == "D")
                {
                    horda.AcumularUT();
                }else
                {
                    Console.WriteLine("Ataque inválido! O herói " + horda.GetNome() + " não atacou nesse turno.");
                }
                Console.WriteLine("=====================================");
                Console.WriteLine("Vida restante do herói " + alianca.GetNome() + " da Aliança: " + alianca.GetPtsVida());

                if (alianca.GetPtsVida() <= 0)
                {
                    Console.WriteLine("O heroi " + horda.GetNome() + " da Horda venceu! e sobrou " + horda.GetPtsVida() + " de vida!");
                    Console.WriteLine("Game Over!");
                    break;
                }
            }
        }
    }
    
	public abstract class Heroi
	{
		protected string nome;
		protected float ptsVida;
	    protected int UTHeroi;
		protected Magia magica;
		protected Arma arma;
		public Heroi (string nome, float ptsVida)
		{
			this.UTHeroi = 7;
			this.nome = nome;
			this.ptsVida = ptsVida;
		}
		
		public abstract void LancarMagia ();
		
		public abstract void AtacarComArma ();

		public virtual void ReduzirVida() 
		{
			this.ptsVida--;
		}
		public virtual void ReduzirVida(float dano)
		{
			this.ptsVida -= dano;
		}

		public virtual void AumentarVida() 
		{
			this.ptsVida++;
		}
		public virtual void AumentarUT(int valor)
		{
			this.UTHeroi+=valor;
		}
		public virtual void ReduzirUT(int valor)
		{
			this.UTHeroi-=valor;
		}
		public string GetNome() 
		{
			return this.nome;
		}

		public float GetPtsVida() 
		{
			return this.ptsVida;
		}

		public virtual int ExibirUT()
		{
			return this.UTHeroi;
		}

        public virtual void AcumularUT()
        {
            
            Console.WriteLine("O herói " + this.nome + " está acumulando energia.");
            this.UTHeroi += 3;
            Console.WriteLine("O herói " + this.nome + " não atacou nesse turno.");
        }
	}


	public class HeroiAlianca : Heroi
	{
		public HeroiAlianca (string nome, float ptsVida) : base (nome, ptsVida)
		{
			this.magica = new Magia ("Força Rutilante", 4, 20);
			this.arma = new Arma ("Espada", 12, 10);
		}

		public override void LancarMagia ()
		{
			Console.WriteLine ("Força Rutilante!!!");
		}

		public override void AtacarComArma() 
		{
			Console.WriteLine ("Golpe de espada!!!");
		}

		public override void AumentarVida ()
		{
			this.ptsVida += 0.2f;
		}
	}


	public class HeroiHorda : Heroi
	{
		public HeroiHorda (string nome, float ptsVida) : base(nome, ptsVida)
		{
			this.magica = new Magia ("Caminho de Chamas", 6, 30);
			this.arma = new Arma ("Machado", 14, 20);
		}
	
		public override void LancarMagia ()
		{
			Console.WriteLine ("Caminho de chamas!");
		}

		public override void AtacarComArma() 
		{
			Console.WriteLine ("Golpe de machado!!!");
		}

		public override void ReduzirVida ()
		{
			this.ptsVida -= 0.8f;
		}

	}


    public class Arma
    {
        protected string nome;
        protected int CustoUT;
        protected float dano;

        public Arma(string nome, int CustoUT, float dano)
        {
            this.nome = nome;
            this.CustoUT = CustoUT;
            this.dano = dano;
        }
        public float Atacar()
        {
            return this.dano;
        }
    }


    public class Magia
    {
        protected string nome;
        protected int CustoUT;
        protected float dano;
        public Magia(string nome, int CustoUT, float dano)
        {
            this.nome = nome;
            this.CustoUT = CustoUT;
            this.dano = dano;
        }
        public float Lancar()
        {
            return this.dano;
        }

    }

}