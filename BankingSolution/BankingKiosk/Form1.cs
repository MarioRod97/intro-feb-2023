using Banking.Domain;

namespace BankingKiosk;

public partial class Form1 : Form
{
    BankAccount _account;

    public Form1()
    {
        InitializeComponent();
        _account = new BankAccount(new StandardBonusCalculator(new StandardBusinessClock(new SystemTime())));
        UpdateBalanceDisplay();
    }

    private void UpdateBalanceDisplay()
    {
        this.Text = $"You currently have a balance of: {_account.GetBalance()}";
    }

    private void depositButton_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Deposit);
    }

    private void withdrawButton_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Withdraw);
    }

    private void DoTransaction(Action<decimal> op)
    {
        try
        {
            var amount = decimal.Parse(amountInput.Text);
            op(amount);
            UpdateBalanceDisplay();
        }
        catch (FormatException)
        {

            MessageBox.Show("Only numbers allowed", "Error on Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (AccountOverdraftException)
        {
            MessageBox.Show("This transaction overdrafts account.", "Error on Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // finally - runs ALWAYS, whether error is thrown or not
            // select all text in the input box
            amountInput.SelectAll();
            // move cursor here
            amountInput.Focus();
        }
    }

    private void amountInput_TextChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        DoTransaction((amount) => MessageBox.Show("You clicked a button, blah" + amount.ToString()));
    }
}