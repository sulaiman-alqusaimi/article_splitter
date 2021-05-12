using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace article_splitter
{
    public partial class Form1 : Form
    {
Label l1;
public TextBox article;
Button splitButton;
        public Form1()
        {
InitializeComponent();
this.CenterToScreen();
this.Text = "مقسم النصوص";
this.IsMdiContainer = true;
l1 = new Label();
l1.Parent = this;
l1.Text = "الصق النص هنا: ";
l1.Location = new Point(30, 10);
this.article = new TextBox();
this.article.Parent = this;
this.article.Multiline = true;
this.article.WordWrap = false;
this.article.TextChanged += onTextChanged; 
this.article.Location = new Point(30, l1.Location.Y+l1.Size.Height+10);
splitButton = new Button();
splitButton.Parent = this;
splitButton.Text = "تقسيم...";
splitButton.Enabled = false;
splitButton.Location = new Point(30+this.article.Size.Height/2, this.article.Location.Y+this.article.Size.Height+10);
splitButton.Click += onSplit;
        }
void onTextChanged(object sender, EventArgs e)
{
splitButton.Enabled = (this.article.Text != "");
}
public void onSplit(object sender, EventArgs e)
{
int factor;
try
{
factor = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("أقصى عدد للأحرف لكل جزء", "أقصى عدد للأحرف في كل جزء", "280"));
}
catch (Exception E)
{
MessageBox.Show("يرجى إدخال عددًا صحيحًا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
article.Focus();
    return;
}
int index = 0;
string[] words = this.article.Text.Split(' ');
List<string> parts = new List<string>();
string part = "";
while (index < words.Length)
{
if ($"{part} {words[index]}".Length <= factor)
{
part = $"{part} {words[index]}";
index++;
}
else 
{
parts.Add(part.Trim());
part = "";
}

} 
if (part != "")
{
parts.Add(part.Trim());

}
this.article.SelectAll();
Result r = new Result(parts.ToArray(), this);
r.Show();

} 
    }

}
