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
class Result: Form
{
Label l1;
ListBox elementsBox;
Button copyButton;
Form1 topWindow;
public Result(string[] elements, Form1 parent)
{
this.MdiParent = parent;
this.Text = "نتيجة التقسيم";
this.CenterToParent();
this.KeyPreview = true;
this.KeyDown += onFormKeyDown;
this.topWindow = parent;
l1 = new Label();
l1.Parent = this;
l1.Text = $"عدد أجزاء النص {elements.Length}. تنقل بينها عبر مفاتيح الأسهم, واضغط على زر النسخ لوضع العنصر المحدد في الذاكرة استعدادًا للصقه";
l1.Location = new Point(20, 30);
elementsBox = new ListBox();
elementsBox.Parent = this;
elementsBox.Location = new Point(l1.Location.X+l1.Size.Width+10, l1.Location.Y);
elementsBox.Items.AddRange(elements);
elementsBox.SelectedIndex = 0;
copyButton = new Button();
copyButton.Parent = this;
copyButton.Text = "نسخ";
copyButton.Location = new Point(this.elementsBox.Location.X+this.elementsBox.Size.Width+10, this.elementsBox.Location.Y); 
copyButton.Click += onCopy;
}
public void onCopy(object sender, EventArgs e)
{
string element = this.elementsBox.GetItemText(this.elementsBox.SelectedItem);
Clipboard.SetText(element);
this.elementsBox.Focus();
}
void onFormKeyDown(object sender, KeyEventArgs e)
{
if (e.KeyCode == Keys.Escape)
{
this.Dispose();
topWindow.article.Focus();
}
}
}
}