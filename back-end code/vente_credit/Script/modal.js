//afficher details vente
function showFormDetailVente(idLivraison) {
  showModalSecond();
  $.ajax({
    type: "POST",
    url: "/PointDeVente/DetailVente",
    data: '{idLivraison : "'+ parseInt(idLivraison) +'" }',
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      document.getElementById('js-body-details').innerHTML = response;
    },
    failure: function (response) {
        alert(response.responseText);
    },
    error: function (response) {
        alert(response.responseText);
    }
  });
}

//afficher formulaire ajout vente carte
function showFormCardSale (idLivraison, pointDeVente) {
  document.getElementById('idLivraison').value = idLivraison;  
  document.getElementById('pointDeVente').value = pointDeVente;
  showModal();
}

//Afficher details livraison
function showDetailsLivraison(idEmpStock) {
  //Afficher modal
  showModalSecond();
  ////////// Fin affichage modal
  $.ajax({
    type: "POST",
    url: "/Coursier/DetailLivraison",
    data: '{employeStock : "'+ parseInt(idEmpStock) +'" }',
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      document.getElementById('js-body-details').innerHTML = response;
    },
    failure: function (response) {
        alert(response.responseText);
    },
    error: function (response) {
        alert(response.responseText);
    }
  });
}
/////////////////////////////////////////////////

//Ajouter une livraison
function showFormLivraison(idEmpStock){
  document.getElementById('idEmployeStock').value = idEmpStock;
  showModal();
}
//////////////////////////////////////////////

$(".js-btn-option").on('click', function() {
    TweenMax.fromTo(".modal-right", 0.5, 
    {
      left: "150%",
      display: "none",
      opacity: "0"
    },
    {
      left: "83%",
      display: "block",
      opacity: "1"
    }
  );
});

//Afficher details distribution
function showDetail(id){

  $.ajax({
    type: "POST",
    url: "/Accueil/DetailDistribution",
    data: '{id: "' + parseInt(id) + '"}',
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      document.getElementById('detail-body').innerHTML = response;
    },
    failure: function (response) {
        alert(response.responseText);
    },
    error: function (response) {
        alert(response.responseText);
    }
  });
  TweenMax.fromTo(".modal-right", 0.5, 
    {
      left: "150%",
      display: "none",
      opacity: "0"
    },
    {
      left: "83%",
      display: "block",
      opacity: "1"
    }
  );
  TweenMax.fromTo(".modal-background-detail", 0.5, 
    {
      display: "none",
      opacity: 0
    },
    {
      display: "block",
      opacity: 0.5
    }
  );
}
/////////////////////////

///////Afficher popup
function showPopup() {
  TweenMax.fromTo(".popup", 0.5, 
    {
      right: "-500px",
    },
    {
      right: "0",
    }
  );
}
//////////////////
////// Fermer le bouton ///////////
$(".popup-close").on('click', function() {
  TweenMax.fromTo(".popup", 0.5, 
    {
      right: "0",
    },
    {
      right: "-500px",
    }
  );
});
////////////

////// Afficher form ajout carte
$(".js-btn-add-card").on('click', function() {
  showModal();
});

//////Fermer modal detail
$(".btn-close-detail").on('click', function() {
  TweenMax.fromTo(".modal-right", 0.5, 
    {
      left: "83%",
      //display: "block",
      //opacity: 1
    },
    {
      left: "150%",
      //display: "none",
      //opacity: 0
    }
  );
  TweenMax.fromTo(".modal-background-detail", 0.5, 
    {
      display: "block",
      opacity: 0.5
    },
    {
      display: "none",
      opacity: 0
    }
  );
});

$(".modal-background-detail").on('click', function() {
  TweenMax.fromTo(".modal-right", 0.5, 
    {
      left: "83%",
      //display: "block",
      //opacity: 1
    },
    {
      left: "150%",
      //display: "none",
      //opacity: 0
    }
  );
  TweenMax.fromTo(".modal-background-detail", 0.5, 
    {
      display: "block",
      opacity: 0.5
    },
    {
      display: "none",
      opacity: 0
    }
  );
});

$(".modal-background").on('click', function() {
  TweenMax.fromTo(".modal", 0.5, 
    {
      display: "block",
      opacity: 1
    },
    {
      display: "none",
      opacity: 0
    }
  );
  TweenMax.fromTo(".modal-background", 0.5, 
    {
      display: "block",
      opacity: 0.5
    },
    {
      display: "none",
      opacity: 0
    }
  );
});

$(".btn-close").on('click', function() {
  TweenMax.fromTo(".modal", 0.5, 
    {
      display: "block",
      opacity: 1
    },
    {
      display: "none",
      opacity: 0
    }
  );
  TweenMax.fromTo(".modal-background", 0.5, 
    {
      display: "block",
      opacity: 0.5
    },
    {
      display: "none",
      opacity: 0
    }
  );
});


$(".btn-close-second").on('click', function() {
  TweenMax.fromTo(".modal-second", 0.5, 
    {
      display: "block",
      opacity: 1
    },
    {
      display: "none",
      opacity: 0
    }
  );
  TweenMax.fromTo(".modal-background", 0.5, 
    {
      display: "block",
      opacity: 0.5
    },
    {
      display: "none",
      opacity: 0
    }
  );
});

function showModal () {
  TweenMax.fromTo(".modal", 0.5, 
    {
      display: "none",
      opacity: 0
    },
    {
      display: "block",
      opacity:1
    }
  );
  TweenMax.fromTo(".modal-background", 0.5, 
    {
      display: "none",
      opacity: 0
    },
    {
      display: "block",
      opacity: 0.5
    }
  );
}

function showModalSecond() {
  TweenMax.fromTo(".modal-second", 0.5, 
    {
      display: "none",
      opacity: 0
    },
    {
      display: "block",
      opacity:1
    }
  );
  TweenMax.fromTo(".modal-background", 0.5, 
    {
      display: "none",
      opacity: 0
    },
    {
      display: "block",
      opacity: 0.5
    }
  );
}