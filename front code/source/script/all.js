//add card sale
$(".btn-add-cardsale").on('click',function(){ 
  $.ajax({
    type: "POST",
    url: "/PointDeVente/VenteCarte",
    data: '{livraison: "' + parseInt($("#idLivraison").val()) + '", quantite: "'+ parseInt($("#quantite").val()) 
      +'",pointDeVente: "' + $("#pointDeVente").val() 
      + '", date_vente: "' + $("#dateVente").val() + '"}',
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      $(".modal-background").click();
      showPopup();
    },
    failure: function (response) {
      alert(response.responseText);
    },
    error: function (response) {
      alert(response.responseText);
    }
  });
});

//new livraison
$(".btn-add-delivery").on('click', function() {
  $.ajax({
    type: "POST",
    url: "/Coursier/Livraison",
    data: '{empStock: "' + parseInt($("#idEmployeStock").val()) + '", employe: "'+ parseInt($("#idEmploye").val()) 
      +'",quantite: "' + parseInt($("#quantite").val()) 
      + '", resteNonVendu: "' + parseInt($("#resteNonVendu").val()) 
      + '", dateLivraison: "' + $("#dateLivraison").val() + '", pointDeVente: "' + parseInt($("#pointDeVente").val()) + '"}',
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      $(".modal-background").click();
      document.getElementById('js-content__body').innerHTML = response;
      showPopup();
    },
    failure: function (response) {
      alert(response.responseText);
    },
    error: function (response) {
      alert(response.responseText);
    }
  });
});

//control type user
$(".js-user").on('click', function() {
  document.getElementById('type-user').value = this.value;
});

//appel controller ajout card
$(".btn-add-card").on('click', function() {
  $.ajax({
    type: "POST",
    url: "/Accueil/InsertCard",
    data: '{carte: "' + parseInt($("#carte").val()) + '", employe: "' + parseInt($("#employe").val()) + '", quantite: "' + parseInt($("#quantite").val()) + '", date: "' + $("#date").val() +'" }',
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      $(".modal-background").click();
      document.getElementById('js-content__body').innerHTML = response;
      showPopup();
    },
    failure: function (response) {
      alert(response.responseText);
    },
    error: function (response) {
      alert(response.responseText);
    }
  });
});