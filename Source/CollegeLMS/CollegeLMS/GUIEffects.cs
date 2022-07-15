using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollegeLMS{
    public class GUIEffects{
        public void changeTextBorder_MO(Panel panel) {//Change Background Colour of Panel on Mouse Hover
            panel.BackColor = System.Drawing.Color.Black;
        }
        public void changeTextBorder_ML(Panel panel) {//Change Background Colour of Panel on Mouse Leave
            panel.BackColor = System.Drawing.Color.FromArgb(0, 207, 247);
        }

        public void changeRadio_Clicked(RadioButton radio) {
            radio.BackColor = System.Drawing.Color.FromArgb(234, 255, 255);
        }

        public void showError(PictureBox pic, Label label, String msg) {//Show Error Status
            pic.Visible = true;
            pic.Image = global::CollegeLMS.Properties.Resources.wrong;

            label.Visible = true;
            label.Text = msg;
            
        }
        public void showOkay(PictureBox pic, Label label, String msg) {//Show Okay Status
            pic.Visible = true;
            pic.Image = global::CollegeLMS.Properties.Resources.ok;

            label.Visible = true;
            label.Text = msg;
        }

        public void showThisHide(Form owner, Form child) {//Show the child form and hide the parent form
            owner.Hide();
            child.Show();
        }
        public void showDialog(Form owner) {//Show Form as a Dialog
            owner.ShowDialog();
        }

        #region SearchResults
        private int resultCount;//Number of Search Results
        private Panel mainPanel;//Results Holder Panel
        public void initResults(int count, Panel panel) {//Initialize the Results Appearance
            resultCount = count;
            mainPanel = panel;

            initControls();//Initialize Results
            buildStructure();//Build Controls
        }

        public void setResultData(int count, String[] data, EventHandler e, Image image) {//Set Data to the controls
            outterPanels[count].Visible = true;
            bookTitle[count].Text = data[0];
            bookAuthor[count].Text = data[1];

            showBook[count].Click += e;
            bookpics[count].Image = image;
        }

        private Panel[] outterPanels;
        private Panel[] innerPanels;
        private PictureBox[] bookpics;
        private Label[] bookTitle;
        private Label[] bookAuthor;
        private Button[] showBook;

        private void initControls() {//Initialize Search Result Controls
            outterPanels = new Panel[resultCount];
            innerPanels = new Panel[resultCount];
            bookpics = new PictureBox[resultCount];
            bookTitle = new Label[resultCount];
            bookAuthor = new Label[resultCount];
            showBook = new Button[resultCount];
            for(int i = 0;i < outterPanels.Length;i++) {
                setOutter(i);
                setInner(i);
                setImage(i);
                setTitle(i);
                setAuthor(i);
                setButton(i);
            }

            buildStructure();
        }
        private void buildStructure() {//Create the Structure of the search results
            int x = 0, y = 0;
            int cont = 0;

            for(int j = 0;j < resultCount;j++) {

                outterPanels[j].Location = new Point(x, y);

                x = outterPanels[j].Location.X + (outterPanels[j].Width + 5);//Set X of Panels

                if((j + 1) % 4 == 0) {
                    y = outterPanels[j].Location.Y + (outterPanels[j].Height + 10);//Set Y of Panels
                    x -= (cont * (outterPanels[j].Width + 4)) + outterPanels[j].Width + 8;
                }

                if(cont >= 4)
                    cont = 0;
                cont++;

                outterPanels[j].Visible = true;
                mainPanel.Controls.Add(outterPanels[j]);
            }
        }

        private void setOutter(int i) {//Outter Panels
            outterPanels[i] = new Panel();
            outterPanels[i].BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            outterPanels[i].ForeColor = Color.Black;
            outterPanels[i].Size = new Size(226, 99);
        }
        private void setInner(int i) {//Inner Panels
            innerPanels[i] = new Panel();
            innerPanels[i].BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            innerPanels[i].ForeColor = Color.Black;
            innerPanels[i].Size = new Size(222, 95);
            innerPanels[i].Location = new Point(2, 2);
            innerPanels[i].MouseEnter += (sender, e) => ShowBooks_MouseEnter(sender, e, i);
            innerPanels[i].MouseLeave += (sender, e) => ShowBooks_MouseLeave(sender, e, i);

            outterPanels[i].Controls.Add(innerPanels[i]);
        }
        private void setImage(int i) {//Book Picture
            bookpics[i] = new PictureBox();
            bookpics[i].SizeMode = PictureBoxSizeMode.StretchImage;
            bookpics[i].Size = new Size(59, 59);
            bookpics[i].Location = new Point(5, 6);
            bookpics[i].Image = null;
            bookpics[i].BackColor = Color.Teal;
            bookpics[i].MouseEnter += (sender, e) => ShowBooks_MouseEnter(sender, e, i);
            bookpics[i].MouseLeave += (sender, e) => ShowBooks_MouseLeave(sender, e, i);

            innerPanels[i].Controls.Add(bookpics[i]);
        }
        private void setTitle(int i) {//Set Book Title
            bookTitle[i] = new Label();
            bookTitle[i].ForeColor = Color.Black;
            bookTitle[i].Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel, ((byte)(0)));
            bookTitle[i].Size = new Size(155, 30);
            bookTitle[i].Location = new Point(65, 4);
            bookTitle[i].TextAlign = ContentAlignment.MiddleLeft;
            bookTitle[i].AutoSize = false;
            bookTitle[i].MouseEnter += (sender, e) => ShowBooks_MouseEnter(sender, e, i);
            bookTitle[i].MouseLeave += (sender, e) => ShowBooks_MouseLeave(sender, e, i);

            innerPanels[i].Controls.Add(bookTitle[i]);
        }
        private void setAuthor(int i) {//Set Book Title
            bookAuthor[i] = new Label();
            bookAuthor[i].ForeColor = Color.Black;
            bookAuthor[i].BackColor = Color.Transparent;
            bookAuthor[i].Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(0)));
            bookAuthor[i].Size = new Size(155, 30);
            bookAuthor[i].Location = new Point(65, 35);
            bookAuthor[i].TextAlign = ContentAlignment.TopLeft;
            bookAuthor[i].AutoSize = false;
            bookAuthor[i].MouseEnter += (sender, e) => ShowBooks_MouseEnter(sender, e, i);
            bookAuthor[i].MouseLeave += (sender, e) => ShowBooks_MouseLeave(sender, e, i);

            innerPanels[i].Controls.Add(bookAuthor[i]);
        }
        private void setButton(int i) {//Set Button
            showBook[i] = new Button();
            showBook[i].BackColor = Color.Teal;
            showBook[i].Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel, ((byte)(0)));
            showBook[i].FlatStyle = FlatStyle.Flat;
            showBook[i].ForeColor = Color.White;
            showBook[i].Cursor = Cursors.Hand;
            showBook[i].Size = new Size(217, 24);
            showBook[i].Location = new Point(3, 68);
            showBook[i].Text = "View";
            showBook[i].TextAlign = ContentAlignment.MiddleCenter;
            showBook[i].MouseEnter += (sender, e) => ShowBooks_MouseEnter(sender, e, i);//Activates on Mouse Enter
            showBook[i].MouseLeave += (sender, e) => ShowBooks_MouseLeave(sender, e, i);//Activates on Mouse Leave

            innerPanels[i].Controls.Add(showBook[i]);
        }

        private void ShowBooks_MouseLeave(object sender, EventArgs e, int i) {//Mouse Leave Controls
            changeTextBorder_ML(outterPanels[i]);
        }
        private void ShowBooks_MouseEnter(object sender, EventArgs e, int i) {//Mouse Enter Controls
            changeTextBorder_MO(outterPanels[i]);
        }
        #endregion
    }
}
