using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // ربط كل العناصر مع الدالة اللي تحدث الملخص
            rbSmall.CheckedChanged += (s, e) => UpdateOrderSummary();
            rbMedium.CheckedChanged += (s, e) => UpdateOrderSummary();
            rbLarge.CheckedChanged += (s, e) => UpdateOrderSummary();

            rbThick.CheckedChanged += (s, e) => UpdateOrderSummary();
            rbThin.CheckedChanged += (s, e) => UpdateOrderSummary();

            chkCheese.CheckedChanged += (s, e) => UpdateOrderSummary();
            chkMushroom.CheckedChanged += (s, e) => UpdateOrderSummary();
            chkTomato.CheckedChanged += (s, e) => UpdateOrderSummary();
            chkOnion.CheckedChanged += (s, e) => UpdateOrderSummary();
            chkOlive.CheckedChanged += (s, e) => UpdateOrderSummary();
            chkPepper.CheckedChanged += (s, e) => UpdateOrderSummary();

            rbEatIn.CheckedChanged += (s, e) => UpdateOrderSummary();
            rbTakeOut.CheckedChanged += (s, e) => UpdateOrderSummary();

            // ربط الأزرار
            btnReset.Click += BtnReset_Click;
            btnOrder.Click += BtnOrder_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dark background
            this.BackColor = Color.FromArgb(15, 15, 15);
            this.Text = "🍕 Premium Pizza World 🍕";

            // أول ما يفتح البرنامج يظهر ملخص افتراضي
            ResetOrder();
        }

        // زرار Reset
        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetOrder();
        }

        private void ResetOrder()
        {
            // افتراضيات الطلب
            rbSmall.Checked = true;
            rbThin.Checked = true;

            chkCheese.Checked = false;
            chkMushroom.Checked = false;
            chkTomato.Checked = false;
            chkOnion.Checked = false;
            chkOlive.Checked = false;
            chkPepper.Checked = false;

            rbEatIn.Checked = true;

            UpdateOrderSummary();
        }

        // زرار Order
        private void BtnOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you want to confirm your order?",
                "Order Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "✅ Your order has been placed successfully!\n\n🍕 Thank you for choosing Premium Pizza World.\nWe wish you a delicious meal! 😋",
                    "Order Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ResetOrder();
            }
            else
            {
                MessageBox.Show(
                    "❌ Your order has been canceled.",
                    "Order Canceled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void UpdateOrderSummary()
        {
            // حساب الحجم
            decimal total = 0;
            string size = "";

            if (rbSmall.Checked) { size = "Small"; total += 10; }
            if (rbMedium.Checked) { size = "Medium"; total += 15; }
            if (rbLarge.Checked) { size = "Large"; total += 20; }

            lblSize.Text = $"Size: {size} - ${total}";

            // حساب العجين
            if (rbThick.Checked)
            {
                total += 5;
                lblCrust.Text = "Crust: Thick Crust - $5";
            }
            else
                lblCrust.Text = "Crust: Thin Crust - Free";

            // حساب الإضافات
            string toppings = "";
            if (chkCheese.Checked) { toppings += "Extra Cheese, "; total += 2.5m; }
            if (chkMushroom.Checked) { toppings += "Mushrooms, "; total += 1.5m; }
            if (chkTomato.Checked) { toppings += "Tomatoes, "; total += 1; }
            if (chkOnion.Checked) { toppings += "Onion, "; total += 1; }
            if (chkOlive.Checked) { toppings += "Olives, "; total += 1.5m; }
            if (chkPepper.Checked) { toppings += "Green Pepper, "; total += 1; }

            lblToppings.Text = string.IsNullOrEmpty(toppings)
                ? "Toppings: None Selected"
                : $"Toppings: {toppings.TrimEnd(',', ' ')}";

            lblWhere.Text = rbEatIn.Checked ? "Where: Eat In" : "Where: Take Out";
            lblTotal.Text = $"Total Price: ${total:F2}";
        }
    }
}
