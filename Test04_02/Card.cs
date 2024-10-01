using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    enum CardState
    {
        Hidden, 
        Show, 
        Matched
    }
    class Card
    {
        int cardNumber;
        CardState state;
        public Card(int cardNumber)
        {
            this.cardNumber = cardNumber;
            state = CardState.Hidden;
        }

        public void setCardState(CardState newState)
        {
            state = newState;
        }

        public CardState getCardState()
        {
            return state;
        }

        public int getCardNumber()
        {
            return cardNumber;
        }
    }
}
