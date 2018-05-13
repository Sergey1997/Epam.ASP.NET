using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BankAccount : IEquatable<BankAccount>
    {
        #region private Fields

        /// <summary>   The identifier of account. </summary>
        private int id;

        /// <summary>   The person. </summary>
        private Client client;

        /// <summary>   Bonus points on the account. </summary>
        private int bonusPoints;

        /// <summary>   Bonus points on the account. </summary>
        private decimal balance;

        /// <summary>   The gradation. </summary>
        private Gradation gradation;

        #endregion

        #region Constructor
        /// <summary>   Constructor. </summary>
        /// <param name="man">          The person with properties: string, string, string, string. </param>
        /// <param name="gradation">    The gradation of account rarity. </param>
        public BankAccount(int id, Client person, Gradation gradation, decimal balance, int points)
        {
            this.Id = id;
            this.Client = new Client(person.Name, person.Surname, person.Lastname, person.NumberOfPassport);
            this.Gradation = gradation;
            this.Balance = balance;
            this.BonusPoints = points;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Getter and setter for identifier of account
        /// </summary>
        public int Id
        {
            get => this.id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{(nameof(value))} cant be less than zero");
                }

                id = value;
            }
        }

        /// <summary>   Gets or sets the balance. </summary>
        /// <value> The balance. </value>
        public decimal Balance
        {
            get => balance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{(nameof(value))} cant be less than zero");
                }

                balance = value;
            }
        }

        /// <summary>   Gets or sets the bonuse points. </summary>
        /// <value> The bonuse points. </value>
        public int BonusPoints
        {
            get => bonusPoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{(nameof(value))} cant be less than zero");
                }

                bonusPoints = value;
            }
        }

        public Client Client
        {
            get => this.client;
            set
            {
                this.client = value ?? throw new ArgumentNullException($"{(nameof(value))} cant be a null");
            }
        }
        public Gradation Gradation
        {
            get => this.gradation;
            set
            {
                if (this.gradation.GetType() != value.GetType())
                {
                    throw new ArgumentException($"{(nameof(value))} should be a {(client.GetType())} type");
                }

                this.gradation = value;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BankAccount);
        }

        public bool Equals(BankAccount other)
        {
            return other != null &&
                   id == other.id &&
                   EqualityComparer<Client>.Default.Equals(client, other.client);
        }

        public override int GetHashCode()
        {
            var hashCode = 1132277856;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(client);
            return hashCode;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nPersonal info: {Client.ToString()}\nBank info\nBalance: {Balance}\nBonusPoints: {BonusPoints}\nGradation: {Gradation}.";
        }
        #endregion
    }
}
