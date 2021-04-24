using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace GastoDiario
{
    [Activity(Label = "Gasto Diario - Login", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        ImageView img;
        TextView lbEmail;
        TextView lbSenha;
        EditText txtEmail;
        EditText txtSenha;
        TextView btnRegistrar;
        Button btnEntrar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            SetContentView(Resource.Layout.activity_main);

            img = FindViewById<ImageView>(Resource.Id.imageViewLogo);
            txtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            txtSenha = FindViewById<EditText>(Resource.Id.edtSenha);

            lbEmail = FindViewById<TextView>(Resource.Id.txtEmail);
            lbEmail.Text = "Email";

            lbSenha = FindViewById<TextView>(Resource.Id.txtSenha);
            lbSenha.Text = "Senha";

            btnRegistrar = FindViewById<TextView>(Resource.Id.btnRegistrar);
            btnRegistrar.Text = "Registra-se";
            btnRegistrar.Click += btnRegistrar_Click;

            btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
            btnEntrar.Text = "Entrar";
            btnEntrar.Click += btnEntrar_Click;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        void btnEntrar_Click(object sender, System.EventArgs e)
        {
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
        }
    }
}