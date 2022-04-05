using System;
using System.Collections.Generic;
using System.Text;

namespace TesteTecnico
{
    public class Credito
    {
        private string _tipoCredito;
        public virtual string TipoCredito
        {
            get { return _tipoCredito; }
            set { _tipoCredito = value; }
        }

        private int _quantidadeParcelas;
        public virtual int QuantidadeParcelas
        {
            get { return _quantidadeParcelas; }
            set { _quantidadeParcelas = value; }
        }        

        private decimal _valorCredito;
        public virtual decimal ValorCredito
        {
            get { return _valorCredito; }
            set { _valorCredito = value; }
        }

        private DateTime _primeiroVencimento;
        public virtual DateTime PrimeiroVencimento
        {
            get { return _primeiroVencimento; }
            set { _primeiroVencimento = value; }
        }

        private string _statusCredito;
        public virtual string StatusCredito
        {
            get { return _statusCredito; }
            set { _statusCredito = value; }
        }

        private decimal _valorJuros;
        public virtual decimal ValorJuros
        {
            get { return _valorJuros; }
            set { _valorJuros = value; }
        }

        public decimal ValorTotalComJuros
        {
            get
            {
                return ValorCredito + ValorJuros;
            }
        }

        public string Validar()
        {
            string mensagem = "";

            if (this.TipoCredito.ToUpper() != "D" && this.TipoCredito.ToUpper() != "C" && this.TipoCredito.ToUpper() != "PJ" && this.TipoCredito.ToUpper() != "PF" && this.TipoCredito.ToUpper() != "I")
                mensagem += "Tipo de Crédito inválido. | ";

            if (this.ValorCredito == 0)
                mensagem += "Valor do Crédito não informado. | ";

            if (this.ValorCredito > 1000000M)
                mensagem += "Valor do Crédito não pode ser superior a R$ 1.000.000,00. | " ;

            if (this.TipoCredito.ToUpper() == "PJ" && this.ValorCredito < 15000M)
                mensagem += "Para o tipo Crédito Pessoa Jurídica o valor mínimo do crédito é de R$ 15.000,00. |";

            if ((this.QuantidadeParcelas < 5) || (this.QuantidadeParcelas > 72))
                mensagem += "Quantidade de parcelas deve estar entre 5 e 72. | ";

            if ((this.PrimeiroVencimento < DateTime.Now.AddDays(15)) || (this.PrimeiroVencimento > DateTime.Now.AddDays(40)))
                mensagem += "Primeiro vencimento deve estar entre D+15 e D+40. |";

            return mensagem;
        }


        public void Processar()
        {                            
            var mensagem = this.Validar();

            if (mensagem != "")
            {
                this.StatusCredito = "Negado";
                Console.WriteLine(this.StatusCredito + " | " + mensagem);
            }
            else
            {
                this.StatusCredito = "Aprovado";

                switch (this.TipoCredito.ToUpper())
                {
                    //utilizaremos o cálculo de juros simples para obter o valor do juros do crédito. juros = capital * taxa * tempo
                    case "D":
                        this.ValorJuros = this.ValorCredito * 0.02M * this.QuantidadeParcelas;
                        break;
                    case "C":
                        this.ValorJuros = this.ValorCredito * 0.01M * this.QuantidadeParcelas;
                        break;
                    case "PJ":
                        this.ValorJuros = this.ValorCredito * 0.05M * this.QuantidadeParcelas;
                        break;
                    case "PF":
                        this.ValorJuros = this.ValorCredito * 0.03M * this.QuantidadeParcelas;
                        break;
                    case "I":
                        this.ValorJuros = this.ValorCredito * (0.09M/12) * this.QuantidadeParcelas;
                        break;
                    default:                        
                        break;
                }

                Console.WriteLine(this.StatusCredito + " | Valor Total com Juros: R$ " + this.ValorTotalComJuros + " | Valor do Juros: R$ " + this._valorJuros);
            }                                                           
        }
    }
}
