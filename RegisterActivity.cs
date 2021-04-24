using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Provider;
using Android.Runtime;
using Android.Graphics;
using AndroidX.AppCompat.App;
using Android.Util;
using Java.IO;
using System.IO;

namespace GastoDiario
{
    [Activity(Label = "Gasto Diario - Criar nova conta")]
    public class RegisterActivity : AppCompatActivity
    {
        TextView lbTitulo;
        TextView lbNome;
        TextView lbEmail;
        TextView lbSenha;
        TextView lbRSenha;
        TextView lbFoto;

        EditText txtNome;
        EditText txtEmail;
        EditText txtSenha;
        EditText txtRSenha;

        ImageView imageView;

        Button btnEntrar;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.register_activity);

            lbTitulo = FindViewById<TextView>(Resource.Id.lbRegistrar);
            lbTitulo.Text = "Registre-se";

            lbNome = FindViewById<TextView>(Resource.Id.lbNome);
            lbNome.Text = "Nome:";

            lbEmail = FindViewById<TextView>(Resource.Id.lbEmail);
            lbEmail.Text = "Email:";

            lbSenha = FindViewById<TextView>(Resource.Id.lbSenha);
            lbSenha.Text = "Senha:";

            lbRSenha = FindViewById<TextView>(Resource.Id.lbRSenha);
            lbRSenha.Text = "Reinsira a senha:";

            lbFoto = FindViewById<TextView>(Resource.Id.lbFoto);
            lbFoto.Text = "Tire uma foto de seu rosto:";

            txtNome = FindViewById<EditText>(Resource.Id.txtNome);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtSenha = FindViewById<EditText>(Resource.Id.txtSenha);
            txtRSenha = FindViewById<EditText>(Resource.Id.txtRSenha);

            imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            imageView.Click += imageView_Click;

            btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
            btnEntrar.Text = "Criar conta";
            btnEntrar.Click += btnEntrar_Click;


        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (data != null)
            {
                base.OnActivityResult(requestCode, resultCode, data);
                global::Android.Graphics.Bitmap bitmap = (Bitmap)data.Extras.Get("data");

                imageView.SetImageBitmap(bitmap);
            }

        }


        void imageView_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }


        void btnEntrar_Click(object sender, System.EventArgs e)
        {

            if (txtNome.Text == "")
            {
                Toast.MakeText(Application.Context, "O campo nome está em branco!", ToastLength.Long).Show();
                return;
            }

            if (txtEmail.Text == "")
            {
                Toast.MakeText(Application.Context, "O campo email está em branco!", ToastLength.Long).Show();
                return;
            }

            if (txtSenha.Text == "")
            {
                Toast.MakeText(Application.Context, "O campo senha está em branco!", ToastLength.Long).Show();
                return;
            }

            if (txtRSenha.Text == "")
            {
                Toast.MakeText(Application.Context, "O campo reincira sua senha está em branco!", ToastLength.Long).Show();
                return;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private string encodeImage(Bitmap bm)
        {
            MemoryStream baos = new MemoryStream();
            bm.Compress(Bitmap.CompressFormat.Jpeg, 100, baos);
            byte[] b = baos.ToArray();
            string encImage = Base64.EncodeToString(b, Base64Flags.Default);

            return encImage;
        }

        private Bitmap decodeImage(string base64)
        {
            byte[] decodedString = Base64.Decode(base64, Base64Flags.Default);
            Bitmap decodedByte = BitmapFactory.DecodeByteArray(decodedString, 0, decodedString.Length);

            return decodedByte;
        }
    }
}