var App = {
    Core: {
        CreateTable: function (id) {
            $("#" + id).DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                }
            });
        }
    },
    Data: {
        demo: 35,
        demo2: "Datos de ...",
        demo3: function (c) {
            let a = 10;
            let b = 30;

            return a + b + c;
        }
    },
    Page: {
        Products: {
            List: {
                OnLoad: function () {
                    App.Core.CreateTable("productos");

                    $(".text-units").click(function (e) {
                        alert("Stock: " + $(this).data("stock") + "\nPedido: " + $(this).data("order"));
                    });

                    $('[data-bs-toggle="tooltip"]').tooltip();
                }
            },
            File: {
                OnLoad: function () {

                }
            }
        }
    }
}