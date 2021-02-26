using System.Windows.Forms;

namespace Profit
{
    public class Treatments
    {
        bool permission = false;

        public bool BasicQuery(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4)
        {
            permission = false;

            if (cb1.Checked || cb2.Checked || cb3.Checked || cb4.Checked)
                permission = true;            

            return permission;                            
        }
        public bool DefaultName(ComboBox cb)
        {
            permission = false;

            if (cb.SelectedItem.ToString() == "TODOS")
                permission = true;            

            return permission;
        }
        public bool OtherName(ComboBox cb)
        {
            permission = false;

            if (cb.SelectedItem.ToString() != "TODOS")
                permission = true;

            return permission;
        }
        public bool BasicQueryWithDefaultName(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, ComboBox combo)
        {
            permission = false;

            if (combo.SelectedItem.ToString() == "TODOS" && BasicQuery(cb1, cb2, cb3, cb4))
                permission = true;

            return permission;
        }
        public bool BasicQueryWithOtherName(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, ComboBox combo)
        {
            permission = false;

            if (combo.SelectedItem.ToString() != "TODOS" && BasicQuery(cb1, cb2, cb3, cb4))
                permission = true;

            return permission;
        }
        public bool OnlyProduct(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, ComboBox combo)
        {
            permission = false;

            if (combo.Name.ToLower().Contains("produto") && !BasicQuery(cb1, cb2, cb3, cb4))
                permission = true;

            return permission;
        }
        public bool ProductToThisClient(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, ComboBox produto, ComboBox cliente)
        {
            permission = false;

            if (produto.Name.ToLower().Contains("produto") && !BasicQuery(cb1, cb2, cb3, cb4) && cliente.SelectedIndex > 0)
                permission = true;

            return permission;
        }

    }
}
