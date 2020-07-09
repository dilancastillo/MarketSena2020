var handler = ePayco.checkout.configure({
    key: '42ced569ee2284185f98351bb1f62578',
    test: true
});
var data = {
    //Parametros compra (obligatorio)
    name: "ASUS VivoBook S15",
    description: "Computadora portátil",
    invoice: "1234",
    currency: "cop",
    amount: "5000",
    tax_base: "0",
    tax: "0",
    country: "co",
    lang: "en",

    //Onpage="false" - Standard="true"
    external: "true",


    //Atributos opcionales
    extra1: "extra1",
    extra2: "extra2",
    extra3: "extra3",
    confirmation: "http://secure2.payco.co/prueba_curl.php",
    response: "http://secure2.payco.co/prueba_curl.php",

    //Atributos cliente
    name_billing: "Andres Perez",
    address_billing: "Carrera 19 numero 14 91",
    type_doc_billing: "cc",
    mobilephone_billing: "3050000000",
    number_doc_billing: "100000000"
}

handler.open(data);