function Confirmacao(titulo, mensagem, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensagem,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.value) {
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}