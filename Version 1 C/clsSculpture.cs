using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _Weight;
        private string _Material;

        [NonSerialized()]
        private static frmSculpture _SculptureDialog;

        public float Weight { get => _Weight; set => _Weight = value; }
        public string Material { get => _Material; set => _Material = value; }

        public override void EditDetails()
        {
            if (_SculptureDialog == null)            
                _SculptureDialog = new frmSculpture();
                _SculptureDialog.SetDetails(this);     

            //_SculptureDialog.SetDetails(_Name, _Date, _Value, _Weight, _Material);

            //if (_SculptureDialog.ShowDialog() == DialogResult.OK)
            //{
            //    _SculptureDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Weight, ref _Material);
            //}
        }
    }
}
