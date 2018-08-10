using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheShoppingList
{
    /// <summary>
    /// class MainForm
    /// Description: This class is for the GUI and user interactions, processing of inputs,
    /// and outputs to the GUI. The MainForm is a Windows Form that shows a GUI for a 
    /// Shopping List Application
    /// </summary>
    public partial class MainForm : Form
    {
        //The object that holds the data and business operations for this application
        ItemManager itemManager = new ItemManager();

        /// <summary>
        /// method MainForm()
        /// Description: This method is the entry point of the form application
        /// and initializes and sets up the GUI. 
        /// Inputs: None
        /// Outputs: None
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        } // end of MainForm()

        /// <summary>
        /// method InitializeGUI()
        /// Description: This sets up the GUI for the first time when
        /// the form loads. 
        /// Inputs: None
        /// Outputs: None
        /// </summary>
        private void InitializeGUI()
        {
            cmbUnits.Items.AddRange(Enum.GetNames(typeof (UnitTypes)));
            cmbUnits.SelectedIndex = (int)UnitTypes.piece;
        } // end of InitializeGUI()

        /// <summary>
        /// method btnAdd_Click(object sender, EventArgs e)
        /// Description: After the user clicks on the Add button, it first validates
        /// the text box entries before creating a ShoppingItem object to add
        /// to the master list in the ItemManager object
        /// Inputs: Event handling objects
        /// Outputs: None 
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = false;

            ShoppingItem item = ReadInput(out success);

            if(success)
            {
                itemManager.AddItem(item);
                UpdateGUI();
            }
        } // end of btnAdd_Click(object sender, EventArgs e)

        /// <summary>
        /// method ReadInput(out bool success)
        /// Description: This creates a new ShoppingItem object for the program after it
        /// validates the data entry of the user input on the GUI
        /// Inputs: None
        /// Outputs: boolean true or false to indicicate success or failure, ShoppingItem object 
        /// </summary>
        private ShoppingItem ReadInput(out bool success)
        {
            success = false;

            ShoppingItem item = new ShoppingItem();

            item.Description = ReadDescription(out success);

            if (!success)
                return null;

            item.Amount = ReadAmount(out success);

            if (!success)
                return null;

            item.Unit = ReadUnit(out success);

            return item;
        } // end of ReadInput(out bool success)

        /// <summary>
        /// method ReadAmount(out bool success)
        /// Description: This validates the data entry of the user input on the GUI
        /// for the amount text box. 
        /// Inputs: None
        /// Outputs: boolean true or false to indicicate success or failure
        ///          double amount (quantity)
        /// </summary>
        private double ReadAmount(out bool success)
        {
            double amount = 0.0;
            success = false;

            if(!double.TryParse(txtAmount.Text, out amount))
            {
                GiveMessage("Wrong Amount");
                txtAmount.Focus();
                txtAmount.SelectionStart = 0;
                txtAmount.SelectionLength = txtAmount.TextLength;
            }
            else
            {
                success = true;
            }

            return amount;
        } // end of ReadAmount(out bool success)

        /// <summary>
        /// method ReadAmount(out bool success)
        /// Description: This validates the data entry of the user input on the GUI
        /// for the description/name text box. 
        /// Inputs: None
        /// Outputs: boolean true or false to indicicate success or failure
        ///          string description (name of item)
        /// </summary>
        private string ReadDescription(out bool success)
        {
            string name = string.Empty;
            success = false;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                GiveMessage("Please enter a descriptive name");
                txtName.Focus();
                txtName.SelectionStart = 0;
                txtName.SelectionLength = txtName.TextLength;
            }
            else
            {
                name = txtName.Text;
                success = true;
            }

            return name;
        } // end of ReadDescription(out bool success)

        /// <summary>
        /// method ReadUnit(out bool success)
        /// Description: This validates the data selection of the user input on the GUI
        /// for the combo selection box for the unit measurement type. 
        /// Inputs: None
        /// Outputs: boolean true or false to indicicate success or failure
        ///          enum UnitTypes value
        /// </summary>
        private UnitTypes ReadUnit(out bool success)
        {
            UnitTypes unit = UnitTypes.piece;
            success = false;

            if (!Enum.IsDefined(typeof(UnitTypes), cmbUnits.SelectedIndex))
            {
                GiveMessage("Please select a valid unit type");
                cmbUnits.Focus();
            }
            else
            {
                unit = (UnitTypes) cmbUnits.SelectedIndex;
                success = true;
            }

            return unit;
        } // end of ReadUnit(out bool success)

        /// <summary>
        /// method GiveMessage(string message)
        /// Description: Generic utility message to indicate an error or problem
        /// to the user with a specific message, ok button, and error icon.
        /// Inputs: string message - Message to display in the text box
        /// Outputs: None 
        /// </summary>
        private void GiveMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // end of GiveMessage(string message)

        /// <summary>
        /// method UpdateGUI()
        /// Description: Updates the GUI for the user including the list box of 
        /// items, name, and quanity in the list box.
        /// Inputs: None
        /// Outputs: None 
        /// </summary>
        public void UpdateGUI()
        {
            string[] list = itemManager.GetItemsInfoString();
            lstItems.Items.Clear();

            if (list == null)
                return;

            for (int i = 0; i < list.Length; i++)
            {
                lstItems.Items.Add(list[i]);
            }
        } // end of UpdateGUI()

        /// <summary>
        /// method lstItems_SelectedIndexChanged(object sender, EventArgs e)
        /// Description: After the user selection on the list box changes
        /// this method fetches the current ShoppingItem object from the list
        /// and pre-populates the user data entry boxes so that is it is
        /// easier for the user to make data changes. 
        /// Inputs: Event handling objects
        /// Outputs: None 
        /// </summary>
        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedindex = lstItems.SelectedIndex;
            ShoppingItem item = null;

            item = itemManager.GetItem(selectedindex);

            if(item != null)
            {
                txtName.Text = item.Description;
                txtAmount.Text = item.Amount.ToString();
                cmbUnits.SelectedIndex = (int) item.Unit;
            }
        } // end of lstItems_SelectedIndexChanged(object sender, EventArgs e)

        /// <summary>
        /// method btnChange_Click(object sender, EventArgs e)
        /// Description: After the user clicks on the change button, the method
        /// first validates the user data entry, validates an existing ShoppingItem
        /// is selected, and then calls the business logic on the itemManager object
        /// to make the changes in the list for that specific ShoppingItem object. 
        /// Inputs: Event handling objects
        /// Outputs: None 
        /// </summary>
        private void btnChange_Click(object sender, EventArgs e)
        {
            int selectedindex = lstItems.SelectedIndex;
            ShoppingItem item = null;
            bool success = false;

            item = ReadInput(out success);
            
            if (success && (item != null) && itemManager.ChangeItem(item, selectedindex))
            {
                UpdateGUI();
            }
            else
            {
                GiveMessage("Error: Did not Change, Please First Select Item to Change");
            }
        } // end of btnChange_Click(object sender, EventArgs e)

        /// <summary>
        /// method btnDelete_Click(object sender, EventArgs e)
        /// Description: After the user clicks on the Delete button, the method
        /// calls the business logic on the itemManager object
        /// to delete the item in the list for that specific ShoppingItem object. 
        /// Inputs: Event handling objects
        /// Outputs: None 
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedindex = lstItems.SelectedIndex;

            if (itemManager.DeleteItem(selectedindex))
            {
                // success
                UpdateGUI();
            }
            else
            {
                GiveMessage("Error: Did not Delete, Please First Select Item to Delete");
            }
        } // end of btnDelete_Click(object sender, EventArgs e)
    } // end of class
} // end of namespace
