using System.Threading.Tasks;
using Microsoft.JSInterop;

public static class JS
    {
        public static ValueTask Focus(this IJSRuntime js, string id)
        {
            return js.InvokeVoidAsync("focus", id);
        }

        public static ValueTask Print(this IJSRuntime js)
        {
            return js.InvokeVoidAsync("boleto");
        }

        public static ValueTask Reload(this IJSRuntime js)
        {
            return js.InvokeVoidAsync("reload");
        }

        public static ValueTask Alerta(this IJSRuntime js, string titulo, string mensagem, string tipo)
        {
            return js.InvokeVoidAsync("Swal.fire", titulo, mensagem, tipo);
        }

        public static ValueTask<bool> Confirmacao(this IJSRuntime js, string titulo, string mensagem, string tipo)
        {
            return js.InvokeAsync<bool>("Confirmacao", titulo, mensagem, tipo);
        }
    }