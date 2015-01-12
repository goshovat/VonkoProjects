   //create the textarea dinamically
  function createTextArea() {
      var dFrag = $(document.createDocumentFragment());
      var textArea = $('textarea');
      $(textArea).css('padding', '10px 15px')
          .css('width', '600px')
          .css('height', '200px')
          .css('border-radius', '10px')
          .css('font-size', '20px')
          .css('font-family', 'Segoe UI')
          .css('outline', 'none')
          .css('margin-top', '40px');

      $(textArea).appendTo(dFrag);
      $(dFrag).appendTo('body');
  };

   //setup the color pickers and attach events

  function setUpColorPickers() {
      $('#picker').colpick({
          flat: true,
          layout: 'hex',
          submit: 0,
          onChange: function(hsb, hex) {
              $('textarea').css('color', '#' + hex);
          }
      });

      $('#picker1').colpick({
          flat: true,
          layout: 'hex',
          submit: 0,
          onChange: function(hsb, hex) {
              $('textarea').css('background', '#' + hex);
          }
      });
  }

  window.onload = function() {
      createTextArea();
      setUpColorPickers();
  }
