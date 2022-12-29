$(document).ready(function () {
  $(".getdate").each(function () {
    $(this).datepicker({
      format: "dd/mm/yyyy",
      language: "pt-BR",
    });
  });
});

// if (!Modernizr.inputtypes.date) {
// };
