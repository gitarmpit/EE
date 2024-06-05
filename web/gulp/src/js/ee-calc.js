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
        this.calc(e.target.id);
      }
      else if (e.keyCode == 27) {
        this.clear();
      }
    }

  }
  calc(targetId) {

  }
  clear() {
  }
}

let currentFormId = null;
let deviceHeight = 0;

let calc_array = [];

let ohmsLaw = null;
let vdiv = null;
let Xl  = null;
let Xc  = null;
let RC  = null;
let tf  = null;
let fw  = null;
let RLC = null;
let dbm = null;
let ripple = null;
let headphone = null;
let sound = null;
let tl = null;
let bat = null;
let bat2 = null;
let wres = null;
let vdrop = null;
let c555 = null;
let wpar = null;

function init_calcs() {
  // instantiate calcs
  ohmsLaw = new EE_Ohms_Law();
  calc_array.push (ohmsLaw);
 
  vdiv = new EE_Vdiv();
  calc_array.push (vdiv);
 
  Xl = new EE_Xl();
  calc_array.push(Xl);

  Xc = new EE_Xc();
  calc_array.push(Xc);

  RC = new EE_RC_Cutoff_Freq();
  calc_array.push(RC);

  tf = new EE_tf();
  calc_array.push(tf);

  fw = new EE_fw();
  calc_array.push(fw);

  RLC = new EE_RLC();
  calc_array.push(RLC);

  dbm = new EE_dbm();
  calc_array.push(dbm);

  ripple = new EE_ripple();
  calc_array.push(ripple);

  headphone = new EE_Headphone();
  calc_array.push(headphone);

  sound = new EE_Sound();
  calc_array.push(sound);

  tl = new EE_tl();
  calc_array.push(tl);

  bat = new EE_Battery();
  calc_array.push(bat);

  bat2 = new EE_Battery2();
  calc_array.push(bat2);

  wres = new EE_WireRes();
  calc_array.push(wres);

  vdrop = new EE_Vdrop();
  calc_array.push(vdrop);

  c555 = new EE_555();
  calc_array.push(c555);

  wpar = new EE_Wpar();
  calc_array.push(wpar);

}

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

  init_calcs();

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
