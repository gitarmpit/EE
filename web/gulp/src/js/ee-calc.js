// ee-calc.js start 

class EE_Calc {
  form_name = '';
  
  constructor (form_name) {
    this.form_name = form_name;
  }

  init() {
    let e = document.getElementById(this.form_name);
    e.onkeydown = (e) => {
      if (e.keyCode == 13) {
        this.calc();
      }
      else if (e.keyCode == 27) {
        this.clear();
      }
    }

  }
  clear() {
  }
}

let ohmsLaw = null;

let calc_array = [];
let currentFormId = null;
let deviceHeight = 0;

function setLgHeight2() {
  if (isNarrowScreen() && currentFormId == null) {
    let lg = document.getElementById('lg');
    const h = window.innerHeight - lg.offsetTop - 50;
    lg.style.height = h + "px";

  }

}

function setLgHeight() {

  let lg = document.getElementById('lg');
  const h = window.innerHeight - lg.offsetTop - 20;
  lg.style.height = h + "px";

  document.getElementById('list-container').style.height = window.innerHeight - 20 + "px";
  document.getElementById('right-container').style.height = window.innerHeight - 20 + "px";

}


function init() {
  currentFormId = null;
  setLgHeight();
  window.addEventListener('resize', () => {
    setLgHeight();
  });

  deviceHeight = window.innerHeight;


  if (isNarrowScreen()) {
    var label = document.getElementById('label-tl-C');
    label.textContent = 'C per u.l.:';
    label = document.getElementById('label-tl-L');
    label.textContent = 'L per u.l.:';
    label = document.getElementById('label-tl-VF');
    label.textContent = 'VF, %:';
    //
    label = document.getElementById('label-dbmw');
    label.textContent = 'Sens. dB/mW:';
    label = document.getElementById('label-dbv');
    label.textContent = 'Sens. dB/V:';

    window.visualViewport.addEventListener('resize', () => {

      if (window.innerHeight == deviceHeight) {
        window.scrollTo(0, 0);
      }

    });

  }

  init_conversions();

  // instantiate calcs
  ohmsLaw = new EE_Ohms_Law();
  calc_array.push (ohmsLaw);
  clear_all();
}

function clear_all() {
  calc_array.forEach ((e) => e.clear());
}


function showForm(formId, title) {
  currentFormId = formId;

  clear_all();

  if (isNarrowScreen()) {
    document.getElementById("list-container").style.display = 'none';
    document.getElementById("form-container").style.display = 'block';
    document.getElementById("right-container").style.display = 'block';
    if (title == null) {
      title = event.target.textContent;
    }
    document.getElementById("form-title-p").textContent = title;
    window.scrollTo(0, 0);
    document.body.style.overflow = 'hidden';
  }
  else {
    document.getElementById("form-title-h3").textContent = event.target.textContent;
    let margin = window.innerWidth - 1100;
    if (margin < 5) {
      margin = 5;
    }
    if (margin > 200) {
      margin = 200;
    }
    document.getElementById(formId).style.marginLeft = margin + "px";
    document.getElementById(formId).style.marginRight = margin + "px";
  }

  var forms = document.querySelectorAll('form');

  forms.forEach(function (form) {
    if (form.id === formId) {
      form.style.display = 'grid';
    } else {
      form.style.display = 'none';
    }
  });

}

function goBack() {
  document.getElementById("list-container").style.display = 'block';
  document.getElementById("form-container").style.display = 'none';
  document.getElementById("right-container").style.display = 'none';
  document.body.style.overflow = '';
  currentFormId = null;
}

function getMaxWidth() {
  const rootStyles = getComputedStyle(document.documentElement);
  return rootStyles.getPropertyValue('--max-width');
}

function isNarrowScreen() {
  // Check if the media query matches the features of a mobile device
  //const maxWidth = getMaxWidth();
  //const mediaQuery = window.matchMedia(`(max-width: ${maxWidth}px)`); 
  //const mediaQuery = window.matchMedia(`(max-width: ${getMaxWidth()})`) 
  const mediaQuery = window.matchMedia('(max-width: 700px)');
  return mediaQuery.matches;
}


function reportError(err) {
  //alert(err);
  if (isNarrowScreen()) {

    var fc = document.getElementById("form-container");
    if (fc != null) {
      fc.classList.add('error-shadow');
      setTimeout(function () {
        fc.classList.remove('error-shadow');
      }, 50);
    }

  }
  else if (currentFormId != null) {
    var form = document.getElementById(currentFormId);

    if (form != null) {
      form.classList.add('error-shadow');

      setTimeout(function () {
        form.classList.remove('error-shadow');
      }, 100);
    }

  }
}

// ee-calc.js end
