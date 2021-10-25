/////* Cuentas */
////$(document).ready(function () {


////    /*Busqueda por Nombre de la cuenta*/
////    ///// Llena el listado  consultando al controlador litado
////    /// Cuenta de Inventario
////    $("#CatalogoId_Inventario_Nombre").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Finanzas/Cuenta",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.CatalogoNombre,
////                            id: item.CatalogoId,
////                            Value: item.CatalogoNombre

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#CatalogoId_Inventario").val(ui.item.id);
////            ///// Busca la cuenta por el ID cuado esta es seleccionada
////            $.ajax({
////                url: "/Finanzas/NumerodeCuenta",
////                type: "POST",
////                //dataType: "json",
////                data: {
////                    Idcuenta: ui.item.id
////                },
////                success: function (data) {
////                    $("#CatalogoId_Inventario_Account").val(data);

////                }
////            }).done(function () { });
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });

////    ///// Llena el listado  consultando al controlador litado
////    /// Cuenta Costo de Venta Nombre
////    $("#CatalogoId_CostodeVenta_Nombre").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Finanzas/Cuenta",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.CatalogoNombre,
////                            id: item.CatalogoId,
////                            Value: item.CatalogoNombre

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#CatalogoId_CostodeVenta").val(ui.item.id);
////            ///// Busca la cuenta por el ID cuado esta es seleccionada
////            $.ajax({
////                url: "/Finanzas/NumerodeCuenta",
////                type: "POST",
////                //dataType: "json",
////                data: {
////                    Idcuenta: ui.item.id
////                },
////                success: function (data) {
////                    $("#CatalogoId_CostodeVenta_Account").val(data);

////                }
////            }).done(function () { });
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });

////    /// Cuenta Costo de Venta Nombre
////    $("#CatalogoId_Devolucion_Nombre").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Finanzas/Cuenta",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.CatalogoNombre,
////                            id: item.CatalogoId,
////                            Value: item.CatalogoNombre

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#CatalogoId_Devolucion").val(ui.item.id);
////            ///// Busca la cuenta por el ID cuado esta es seleccionada
////            $.ajax({
////                url: "/Finanzas/NumerodeCuenta",
////                type: "POST",
////                //dataType: "json",
////                data: {
////                    Idcuenta: ui.item.id
////                },
////                success: function (data) {
////                    $("#CatalogoId_Devolucion_Account").val(data);

////                }
////            }).done(function () { });
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });
////    /*--------------------------------------------------------------*/


////    /*Busqueda por Numero de la cuenta*/
////    $("#CatalogoId_Inventario_Account").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Finanzas/Cuenta",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.Cuenta,
////                            id: item.CatalogoId,
////                            Value: item.Cuenta

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#CatalogoId_Inventario").val(ui.item.id);
////            ///// Busca la cuenta por el ID cuado esta es seleccionada
////            $.ajax({
////                url: "/Finanzas/NombreCuenta",
////                type: "POST",
////                //dataType: "json",
////                data: {
////                    Idcuenta: ui.item.id
////                },
////                success: function (data) {
////                    $("#CatalogoId_Inventario_Nombre").val(data);
////                }
////            }).done(function () { });
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });

////    ///// Llena el listado  consultando al controlador litado
////    /// Cuenta Costo de Venta Nombre
////    $("#CatalogoId_CostodeVenta_Account").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Finanzas/Cuenta",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.Cuenta,
////                            id: item.CatalogoId,
////                            Value: item.Cuenta

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#CatalogoId_CostodeVenta").val(ui.item.id);
////            ///// Busca la cuenta por el ID cuado esta es seleccionada
////            $.ajax({
////                url: "/Finanzas/NombreCuenta",
////                type: "POST",
////                //dataType: "json",
////                data: {
////                    Idcuenta: ui.item.id
////                },
////                success: function (data) {
////                    $("#CatalogoId_CostodeVenta_Nombre").val(data);

////                }
////            }).done(function () { });
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });

////    /// Cuenta Costo de Venta Nombre
////    $("#CatalogoId_Devolucion_Account").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Finanzas/Cuenta",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.Cuenta,
////                            id: item.CatalogoId,
////                            Value: item.Cuenta

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#CatalogoId_Devolucion").val(ui.item.id);
////            ///// Busca la cuenta por el ID cuado esta es seleccionada
////            $.ajax({
////                url: "/Finanzas/NombreCuenta",
////                type: "POST",
////                //dataType: "json",
////                data: {
////                    Idcuenta: ui.item.id
////                },
////                success: function (data) {
////                    $("#CatalogoId_Devolucion_Nombre").val(data);

////                }
////            }).done(function () { });
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });



////    /* Clases */

////    /*Busqueda por Nombre de la cuenta*/
////    ///// Llena el listado  consultando al controlador litado
////    /// Cuenta de Inventario
////    $("#ClaseDeArticulo_Nombre").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Inventory/GetClase",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.Nombre,
////                            id: item.ClaseDeArticuloId,
////                            Value: item.Nombre

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#ClaseDeArticuloId").val(ui.item.id);
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });


////    /* unidad de Medida */

////    /*Busqueda por Nombre de la cuenta*/
////    ///// Llena el listado  consultando al controlador litado
////    $("#UnidadDeMedidaNombre").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Inventory/GetUnidadDeMedida",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.Nombre,
////                            id: item.UnidadDeMedidaId,
////                            Value: item.Nombre

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#UnidadDeMedidaId").val(ui.item.id);
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });




////    /* Precio / Busqueda de Articulo */

////    /*Busqueda por Nombre del Articulo*/
////    ///// Llena el listado  consultando al controlador listado
////    /// Nombre del articulo
////    $("#ArticuloNombre").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Inventory/GetItem",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.Nombre,
////                            id: item.ArticuloId,
////                            Value: item.Nombre

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#ArticuloId").val(ui.item.id);
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });

////    $("#ArticuloId").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                url: "/Inventory/GetItem",
////                type: "POST",
////                dataType: "json",
////                data: { Prefix: request.term },
////                success: function (data) {
////                    response($.map(data, function (item) {
////                        return {
////                            label: item.ArticuloId,
////                            id: item.Nombre,
////                            Value: item.ArticuloId

////                        };
////                    }));

////                }
////            });
////        },
////        ///// Al seleccionar COlocar el ID de cuenta
////        select: function (event, ui) {
////            $(this).val(ui.item.value);
////            $("#ArticuloNombre").val(ui.item.id);
////        },
////        minLength: 0,
////        autoFocus: true,
////        messages: {
////            noResults: "", results: function (resultsCount) { }
////        }
////    });

////});