using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        const float opacity = 0.3f;
        Button[] buttons;
        const int rowNum = 4;
        const int colNum = 5;
        Model model;
        Image[] cardImageArray;
        Image[] cardImage반투명Array;

        public Form1()
        {
            InitializeComponent();
            buttons = new Button[] { button0, button1, button2, button3, button4, button5, button6, button7, button8, button9,
                                    button10, button11, button12, button13, button14, button15, button16, button17, button18, button19};
            loadImage();
            model = new Model(rowNum, colNum);
        }

        private void loadImage()
        {
            Image cardsImage = Properties.Resources.Cards;
            int width = cardsImage.Width;
            int height = cardsImage.Height;
            int cardWidth = width / 7;
            int cardHeight = height / 2;
            cardImageArray = new Image[14];
            cardImage반투명Array = new Image[14];

            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    var bmp = new Bitmap(cardWidth, cardHeight);
                    using(var gr = Graphics.FromImage(bmp))
                    {
                        gr.DrawImage(cardsImage,
                                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                                        j * cardWidth, i * cardHeight, cardWidth, cardHeight,
                                        GraphicsUnit.Pixel);
                    }
                    cardImageArray[i * 7 + j] = bmp;

                    bmp = new Bitmap(cardWidth, cardHeight);
                    using(var gr = Graphics.FromImage(bmp))
                    {
                        ColorMatrix colorMatrix = new ColorMatrix();
                        colorMatrix.Matrix33 = opacity;
                        ImageAttributes imgAttribute = new ImageAttributes();
                        imgAttribute.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        gr.DrawImage(cardsImage,
                                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                                        j * cardWidth, i * cardHeight, cardWidth, cardHeight,
                                        GraphicsUnit.Pixel, imgAttribute);
                    }
                    cardImage반투명Array[i * 7 + j] = bmp;
                }
            }

            for(int i = 0; i < rowNum * colNum; i++)
            {
                buttons[i].BackgroundImage = cardImageArray[cardImageArray.Length - 1];
            }//수정사항
        }

        private void refresh()
        {
            CardState cardState;
            int cardNumber;
            Image newImage = null;

            for(int i = 0; i < rowNum; i++)
            {
                for(int j = 0; j < colNum; j++)
                {
                    int index = i * colNum + j;
                    cardState = model.getCardState(index);
                    cardNumber = model.getCardNumber(index);
                    
                    switch(cardState)
                    {
                        case CardState.Show:
                            newImage = cardImageArray[cardNumber];
                            break;
                        case CardState.Matched:
                            newImage = cardImage반투명Array[cardNumber];
                            break;
                        default:
                            newImage = cardImageArray[cardImageArray.Length - 1];
                            break;
                    }
                    
                    if(buttons[index].BackgroundImage != newImage)
                    {
                        buttons[index].BackgroundImage = newImage;
                    } 
                }
            }

            totalClickNumLabel.Text = "총 클릭수 : " + model.getTotalClickCount();
            correctMatchNumLabel.Text = "correct : " + model.getCrrectNum();
            incorrectMatchNumLabel.Text = "wrong : " + model.getWrongNum();
                
        }

        private void button_Click(int buttonIndex)
        {
            if(model.종료체크())
            {
                DialogResult dialogResult = MessageBox.Show("새로운게임", "New Game", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    model.reset();
                    refresh();
                }
                
            }
            else
            {
                if(model.selectedCard(buttonIndex))
                {
                    refresh();
                }
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            button_Click(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_Click(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_Click(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_Click(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_Click(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button_Click(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button_Click(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button_Click(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button_Click(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button_Click(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button_Click(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button_Click(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button_Click(12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button_Click(13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button_Click(14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button_Click(15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button_Click(16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button_Click(17);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button_Click(18);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button_Click(19);
        }
    }
}
