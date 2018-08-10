using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShoppingList
{
    /// <summary>
    /// class ItemManager
    /// Description: This class is for the business logic end and application work
    /// that is done for the GUI. All relevent fields, methods (behaviors), data
    /// for the application is housed in this class object. This class creates and
    /// holds an list of ShoppingItem objects and each object holds its own data and
    /// applicable methods. 
    /// </summary>
    class ItemManager
    {
        // Main List to Hold Items for the Shopping List program
        private List<ShoppingItem> itemList;

        // Property returns the total items on the list
        public int Count {

            get
            {
                return itemList.Count;
            }
        } // end of Count

        /// <summary>
        /// method ItemManager()
        /// Description: Constructor for the ItemManager class
        /// Instantiates the itemList object with ShoppingItem type objects
        /// Inputs: None
        /// Outputs: None
        /// </summary>
        public ItemManager()
        {
            itemList = new List<ShoppingItem>();

        } // end of ItemManager()

        /// <summary>
        /// method GetItem(int index)
        /// Description: Finds and returns the ShoppingItem object
        /// in the master list itemList based on an index of 
        /// which it first validates
        /// Inputs: int index
        /// Outputs: ShoppingItem object
        /// </summary>
        public ShoppingItem GetItem(int index)
        {
            if (!CheckIndex(index))
                return null;

            return itemList[index];
        } // end of GetItem(int index)

        /// <summary>
        /// method AddItem(ShoppingItem itemIn)
        /// Description: Takes the input ShoppingItem object and adds
        /// it to the end of the master list itemList after it checks that
        /// the input object is valid. 
        /// Inputs: ShoppingItem itemIn
        /// Outputs: boolean true or false to indicicate success or failure 
        /// </summary>
        public bool AddItem(ShoppingItem itemIn)
        {
            bool ok = false;

            if(itemIn != null)
            {
                itemList.Add(itemIn);
                ok = true;
            }

            return ok;
        } // end of AddItem(ShoppingItem itemIn)

        /// <summary>
        /// method CheckIndex(int index)
        /// Description: Checks the validity of the input index to make
        /// sure an item can be referenced at that index in the master 
        /// list itemList
        /// Inputs: int index
        /// Outputs: boolean true or false to indicicate success or failure 
        /// </summary>
        private bool CheckIndex(int index)
        {
            bool ok = false;

            if((index >= 0) && index < Count)
            {
                ok = true;
            }

            return ok;
        } // end of CheckIndex(int index)

        /// <summary>
        /// method ChangeItem(ShoppingItem itemIn, int index)
        /// Description: Changes the ShoppingItem object data at a 
        /// specified index in the master list itemList but first
        /// it validates the input index 
        /// Inputs: ShoppingItem itemIn, int index
        /// Outputs: boolean true or false to indicicate success or failure 
        /// </summary>
        public bool ChangeItem(ShoppingItem itemIn, int index)
        {
            bool ok = false;
            if(CheckIndex(index))
            {
                itemList[index].Description = itemIn.Description;
                itemList[index].Amount = itemIn.Amount;
                itemList[index].Unit = itemIn.Unit;
                ok = true;
            }

            return ok;
        } // end oof ChangeItem(ShoppingItem itemIn, int index)

        /// <summary>
        /// method ChangeItem(ShoppingItem itemIn, int index)
        /// Description: Deletes the ShoppingItem object data at a 
        /// specified index in the master list itemList but first
        /// it validates the input index is correct
        /// Inputs: int index
        /// Outputs: boolean true or false to indicicate success or failure 
        /// </summary>
        public bool DeleteItem(int index)
        {
            bool ok = false;

            if(CheckIndex(index))
            {
                itemList.RemoveAt(index);
                ok = true;
            }

            return ok;
        } // end of DeleteItem(int index)

        /// <summary>
        /// method GetItemsInfoString()
        /// Description: Translates the ShoppingItem object data into a string
        /// and for each object and string value is added to an array. The array of
        /// ShoppingItem object data strings is returned to be output to the GUI
        /// list box
        /// Inputs: None
        /// Outputs: string[] (array of strings representing each item)
        /// </summary>
        public string[] GetItemsInfoString()
        {
            string[] stringInfoStrings = new string[itemList.Count];

            int i = 0;

            foreach (ShoppingItem item in itemList)
            {
                stringInfoStrings[i++] = item.ToString();
            }

            return stringInfoStrings;
        } // end of GetItemsInfoString()

    } //  end of class
} //  end of namespace
