using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Model
    {
        int rowNum;
        int colNum;
        Card[] cards;
        int totalClickCount;
        int correctNum;
        int wrongNum;
        public Model(int rowNum, int colNum)
        {
            this.rowNum = rowNum;
            this.colNum = colNum;

            cards = new Card[rowNum * colNum];

            reset();
        }

        public void reset()
        {
            List<int> cardNumber = new List<int>();
            for(int i = 0; i < 13; i++)
            {
                cardNumber.Add(i);
            }

            Random r = new Random();
            int[] intArray = new int[rowNum * colNum / 2];
            for(int i = 0; i < rowNum * colNum / 2; i++)
            {
                int index = r.Next(cardNumber.Count);
                int cardNum = cardNumber[index];
                cardNumber.Remove(cardNum);

                intArray[i] = cardNum;
            }
            int[] intArrayDouble = intArray.Concat(intArray).ToArray();
            intArrayDouble = intArrayDouble.OrderBy(x => r.Next()).ToArray();

            for(int i =0; i < rowNum * colNum; i++)
            {
                cards[i] = new Card(intArrayDouble[i]);
                cards[i].setCardState(CardState.Hidden);
            }
        }

        public bool 종료체크()
        {
            for(int i = 0; i < rowNum * colNum; i++)
            {
                if(cards[i].getCardState() != CardState.Matched)
                {
                    return false;
                }
            }
            return true;
        }

        public CardState getCardState(int cardNumber)
        {
            return cards[cardNumber].getCardState();
        }

        public int getCardNumber(int cardNumber)
        {
            return cards[cardNumber].getCardNumber();
        }

        public bool selectedCard(int index)
        {
            totalClickCount++;
            if(2 <= 오픈카드수())
            {
                오픈카드덮기();
            }

            bool hasStatusChanged = false;
            switch(cards[index].getCardState())
            {
                case CardState.Show:
                    cards[index].setCardState(CardState.Hidden);
                    hasStatusChanged = true;
                    break;
                case CardState.Hidden:
                    cards[index].setCardState(CardState.Show);
                    hasStatusChanged = true;
                    break;
            }

            if(카드매칭여부())
            {
                hasStatusChanged = true;
            }

            return hasStatusChanged;
        }

        private int 오픈카드수()
        {
            int count = 0;
            for (int i = 0; i < rowNum * colNum; i++)
            {
                
                if(cards[i].getCardState() == CardState.Show)
                {
                    count++;
                }
            }
            return count;
        }

        private void 오픈카드덮기()
        {
            for(int i = 0; i < rowNum * colNum; i++)
            {
                if(cards[i].getCardState() == CardState.Show)
                {
                    cards[i].setCardState(CardState.Hidden);
                }
            }
        }

        private bool 카드매칭여부()
        {
            if(오픈카드수() < 2)
            {
                return false;
            }

            List<Card> 오픈카드list = new List<Card>();
            for(int i = 0; i < rowNum * colNum; i++)
            {
                if(cards[i].getCardState() == CardState.Show)
                {
                    오픈카드list.Add(cards[i]);
                }
            }

           if(2 <= 오픈카드list.Count)
            {
                Card 첫번째카드 = 오픈카드list[0];
                Card 두번째카드 = 오픈카드list[1];
                if(첫번째카드.getCardNumber() == 두번째카드.getCardNumber())
                {
                    첫번째카드.setCardState(CardState.Matched);
                    두번째카드.setCardState(CardState.Matched);

                    correctNum++;

                    return true;
                }
                else
                {
                    wrongNum++;
                }
            }

            return false;
        }

        public int getTotalClickCount()
        {
            return totalClickCount;
        }

        public int getCrrectNum()
        {
            return correctNum;
        }
        
        public int getWrongNum()
        {
            return wrongNum;
        }
    }
}
