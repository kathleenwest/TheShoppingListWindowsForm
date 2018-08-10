using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShoppingList
{
    /// <summary>
    /// class ShoppingItem
    /// Description: This class creates ShoppingItem objects that house data
    /// to describe the name, amount, and measurement unit type of what the user
    /// entered on the main GUI form. The ItemManager class creates a list of
    /// ShoppingItem objects and manages the business logic such as adding,
    /// deleting, and changing the ShoppingItem objects.
    /// </summary>
    class ShoppingItem
    {
        // Class Instance Variables for Object Data
        private string description; // Name or Description of the Item
        private double amount;      // Amount or Quanity of the Item
        private UnitTypes unit;     // Measurement Unit of the Item

        // Property to Get/Set the Description
        public string Description {
            get
            {
                return description;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                    description = value;
            }
        } // end of Description

        // Property to Get/Set the Amount
        public double Amount {
            get
            {
                return amount;
            }
            set
            {
                if(value >= 0)
                    amount = value;
            }
        } // end of Amount

        // Property to Get/Set the Unit
        public UnitTypes Unit {
            get
            {
                return unit;
            }
            set
            {
                if(Enum.IsDefined(typeof (UnitTypes),value))
                    unit = value;
            }
        } // end of Unit

        /// <summary>
        /// method ShoppingItem()
        /// Description: Constructor for the ShoppingItem Class.
        /// Creates a ShoppingItem with Defaults: description, amount, and unit type
        /// Inputs: None
        /// Outputs: None
        /// </summary>
        public ShoppingItem() : this("Unknown", 1.0, UnitTypes.piece)
        {

        } // end of ShoppingItem()

        /// <summary>
        /// method ShoppingItem()
        /// Description: Constructor for the ShoppingItem Class.
        /// Creates a ShoppingItem with Defaults: amount, and unit type
        /// Inputs: string description
        /// Outputs: None
        /// </summary>
        public ShoppingItem(string description): this(description, 1.0, UnitTypes.piece)
        {

        } // end of ShoppingItem(string description)

        /// <summary>
        /// method ShoppingItem()
        /// Description: Constructor for the ShoppingItem Class.
        /// Creates a ShoppingItem with Defaults: unit type
        /// Inputs: string description and double amount
        /// Outputs: None
        /// </summary>
        public ShoppingItem(string description, double amount) : this(description, amount, UnitTypes.piece)
        {

        } // end of ShoppingItem(string description, double amount)

        /// <summary>
        /// method ShoppingItem()
        /// Description: Constructor for the ShoppingItem Class.
        /// Creates a ShoppingItem with all specified inputs
        /// Inputs: string description, double amount, and UnitTypes unit
        /// Outputs: None
        /// </summary>
        public ShoppingItem(string description, double amount, UnitTypes unit)
        {
            this.description = description;
            this.amount = amount;
            this.unit = unit;
        } // end of ShoppingItem(string description, double amount, UnitTypes unit)

        /// <summary>
        /// method ShoppingItem()
        /// Description: Creates a string describing the ShoppingItem object data
        /// values of name/description, amount, and UnitType for output to the listbox
        /// on the GUI. 
        /// Inputs: None
        /// Outputs: string (combination of name/description, amount, and UnitType)
        /// </summary>
        public override string ToString()
        {
            string textOut = string.Empty;
            textOut = $"{description, -45} {amount, 6:f2} {unit, -6}";
            return textOut;
        } // end of ToString()

    } // end of class
} // end of namespace
