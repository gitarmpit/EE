
let precision = 3;
let tc_default_Zo = 50;
let Vc = 3 * Math.pow(10, 8);
let GThr = 0;
let MThr = 0;
let kThr = 0;
let baseThr = 0;
let mThr = 0;
let uThr = 0;
let nThr = 0;
let pThr = 0;
let fThr = 0;
let currentFormId = null;
let deviceHeight = 0;

function init() {
  deviceHeight = window.innerHeight;

  GThr = set_threshold(1e12);
  MThr = set_threshold(1e9);
  kThr = set_threshold(1e6);
  baseThr = set_threshold(1e3);
  mThr = set_threshold(1);
  uThr = set_threshold(1e-3);
  nThr = set_threshold(1e-6);
  pThr = set_threshold(1e-9);
  fThr = set_threshold(1e-12);

  let e = document.getElementById('form-ohm');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      ohms_law();
    }
    else if (e.keyCode == 27) {
      ohms_law_clear();
    }
  }

  e = document.getElementById('form-Xl');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      calc_Xl();
    }
    else if (e.keyCode == 27) {
      Xl_clear();
    }
  }

  e = document.getElementById('form-Xc');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      calc_Xc();
    }
    else if (e.keyCode == 27) {
      Xc_clear();
    }
  }

  e = document.getElementById('form-RC');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      calc_cutoff_freq();
    }
    else if (e.keyCode == 27) {
      RC_clear();
    }
  }

  e = document.getElementById('form-tf');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      time_freq_conv();
    }
    else if (e.keyCode == 27) {
      tf_clear();
    }
  }

  //form-fw
  e = document.getElementById('form-fw');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      freq_wl_conv();
    }
    else if (e.keyCode == 27) {
      fw_clear();
    }
  }

  //form-RLC
  e = document.getElementById('form-RLC');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      rlc_calc();
    }
    else if (e.keyCode == 27) {
      rlc_clear();
    }
  }

  //form-dbm
  e = document.getElementById('form-dbm');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      dbm_calc();
    }
    else if (e.keyCode == 27) {
      dbm_clear();
    }
  }

  //form-ripple
  e = document.getElementById('form-ripple');
  document.getElementById('form-ripple-f').value = "60";
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      ripple_calc();
    }
    else if (e.keyCode == 27) {
      ripple_clear();
    }
  }

  //form-headphone
  e = document.getElementById('form-headphone');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      headphone_calc();
    }
    else if (e.keyCode == 27) {
      headphone_clear();
    }
  }
  // form-sound
  e = document.getElementById('form-sound');
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      sound_calc(e.target.id);
    }
    else if (e.keyCode == 27) {
      sound_clear();
    }
  }

  // form-tl
  e = document.getElementById('form-tl');
  document.getElementById('form-tl-Zo').value = tc_default_Zo;
  e.onkeydown = function (e) {
    if (e.keyCode == 13) {
      tl_calc(e.target.id);
    }
    else if (e.keyCode == 27) {
      tl_clear();
    }
  }

  if (isMobileDevice()) {
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

}

function ohms_law_clear() {
  document.getElementById('form-ohm-V').value = "";
  document.getElementById('form-ohm-R').value = "";
  document.getElementById('form-ohm-I').value = "";
  document.getElementById('form-ohm-P').value = "";
}

function Xl_clear() {
  document.getElementById('form-Xl-L').value = "";
  document.getElementById('form-Xl-Xl').value = "";
  document.getElementById('form-Xl-freq').value = "";

}

function Xc_clear() {
  document.getElementById('form-Xc-C').value = "";
  document.getElementById('form-Xc-Xc').value = "";
  document.getElementById('form-Xc-freq').value = "";

}

function RC_clear() {
  document.getElementById('form-RC-C').value = "";
  document.getElementById('form-RC-R').value = "";
  document.getElementById('form-RC-freq').value = "";
  document.getElementById('form-RC-t').value = "";

}

function tf_clear() {
  document.getElementById('form-tf-t').value = "";
  document.getElementById('form-tf-f').value = "";
}

function fw_clear() {
  document.getElementById('form-fw-wl').value = "";
  document.getElementById('form-fw-f').value = "";
}

function rlc_clear() {
  document.getElementById('form-RLC-R').value = "";
  document.getElementById('form-RLC-L').value = "";
  document.getElementById('form-RLC-C').value = "";
  document.getElementById('form-RLC-freq').value = "";
  document.getElementById('form-RLC-Qs').value = "";
  document.getElementById('form-RLC-Qp').value = "";

}

function dbm_clear() {
  document.getElementById('form-dbm-P').value = "";
  document.getElementById('form-dbm-dbm').value = "";
  document.getElementById('form-dbm-Vrms').value = "";
  document.getElementById('form-dbm-Vpk').value = "";
  document.getElementById('form-dbm-Vpp').value = "";
}

function ripple_clear() {
  document.getElementById('form-ripple-f').value = "60";
  document.getElementById('form-ripple-C').value = "";
  document.getElementById('form-ripple-V').value = "";
  document.getElementById('form-ripple-I').value = "";
}

function headphone_clear() {
  document.getElementById('form-headphone-sensitivity-dbmw').value = "";
  document.getElementById('form-headphone-sensitivity-dbv').value = "";
  document.getElementById('form-headphone-R').value = "";
  document.getElementById('form-headphone-P').value = "";
  document.getElementById('form-headphone-V').value = "";
  document.getElementById('form-headphone-I').value = "";
  document.getElementById('form-headphone-loudness').value = "";
}

function sound_clear() {
  document.getElementById('form-sound-db').value = "";
  document.getElementById('form-sound-V').value = "";
  document.getElementById('form-sound-P').value = "";
  document.getElementById('form-sound-L').value = "";
}

function tl_clear() {
  document.getElementById('form-tl-Zo').value = tc_default_Zo;
  document.getElementById('form-tl-C').value = "";
  document.getElementById('form-tl-L').value = "";
  document.getElementById('form-tl-t').value = "";
  document.getElementById('form-tl-len').value = "";
  document.getElementById('form-tl-VF').value = "";
}

function showForm(formId, title) {
  currentFormId = formId;

  if (isMobileDevice()) {
    document.getElementById("list-container").style.display = 'none';
    document.getElementById("form-container").style.display = 'block';
    document.getElementById("right-container").style.display = 'block';
    if (title == null){
      title = event.target.textContent;
    }
    document.getElementById("form-title-p").textContent = title;
    window.scrollTo(0, 0);
    document.body.style.overflow = 'hidden';
  }
  else {
    document.getElementById("form-title-h3").textContent = event.target.textContent;
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
}

function getMaxWidth() {
  const rootStyles = getComputedStyle(document.documentElement);
  return rootStyles.getPropertyValue('--max-width');
}

function isMobileDevice() {
  // Check if the media query matches the features of a mobile device
  //const maxWidth = getMaxWidth();
  //const mediaQuery = window.matchMedia(`(max-width: ${maxWidth}px)`); 
  //const mediaQuery = window.matchMedia(`(max-width: ${getMaxWidth()})`) 
  const mediaQuery = window.matchMedia('(max-width: 700px)');
  return mediaQuery.matches;
}


function reportError(err) {
  //alert(err);
  console.log(currentFormId);
  if (isMobileDevice()) {

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

function initKeyHandler(e) {
}

function set_threshold(m) {
  return m * (1 - Math.pow(10, -(precision + 1)));
}


function parse_float(str, negativeAllowed) {
  if ((negativeAllowed == null || negativeAllowed === false) && str.charAt(0) == '-') {
    throw "Error parsing " + str;
  }
  let regex = /^[0-9e\-+.]+$/;
  let res = str.match(regex);
  if (res == null || res.length != 1) {
    throw "Error parsing " + str;
  }
  return Number.parseFloat(res[0]);
}

function parse_int(str) {
  if (str.charAt(0) == '-') {
    throw "Error parsing " + str;
  }
  let regex = /^[0-9e]+$/;
  let res = str.match(regex);
  if (res == null || res.length != 1) {
    throw "Error parsing " + str;
  }
  return Number.parseInt(res[0]);
}

function float_to_string(val, prec) {
  if (prec == null) {
    prec = precision;
  }
  if (val == 0) {
    return "0";
  }
  else if (Math.abs(val) > 0.0000001 && val < Math.abs(1000000)) {
    if (Math.abs(val) > 0.001) {
      return strip_zeroes(val.toFixed(prec));
    }
    else {
      return strip_zeroes(val.toFixed(6));
    }
  }
  else {
    return val.toExponential(3);
  }
}

function parse_value(str) {
  if (str.charAt(0) == '-') {
    throw "Error parsing " + str;
  }
  let regex = /^([0-9e\-+.]+)([A-Za-z]*)$/;
  str = str.replace(/\s/g, '');
  let res = str.match(regex);

  if (res == null || res.length != 3) {
    throw "Error parsing " + str;
  }
  return [res[1], res[2]];
}

function strip_zeroes(s) {
  if (!s.includes("e")) {
    return s.replace(/(-?\d*\.\d*?)0+$/, '$1').replace(/\.$/, '');
  }
  else {
    return s;
  }
}

// L
function str_to_L(str_L) {
  let val = parse_value(str_L);
  let L = val[0];
  let k = 0;
  if (val[1].toLowerCase() == "h" || val[1].toLowerCase() == "") {
    k = 1;
  }
  else if (val[1].toLowerCase() == "m" || val[1].toLowerCase() == "mh") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "uh") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "nh") {
    k = 1e-9;
  }

  if (k == 0) {
    throw "error parsing L: " + str_L;
  }

  L *= k;
  if (isNaN(L) || !isFinite(L)) {
    throw "error parsing L: " + str_L;
  }

  return L;
}

function L_to_str(L) {
  let units = "H";

  if (L == 0 || !isFinite(L) || isNaN(L)) {
    throw "error parsing L: " + L;
  }

  else if (L < pThr || L > baseThr) {
    return L.toExponential(precision) + "H";
  }

  else if (L < nThr) {
    L *= 1e9;
    units = "nH";
  }
  else if (L < uThr) {
    L *= 1e6;
    units = "uH";
  }
  else if (L < mThr) {
    L *= 1e3;
    units = "mH";
  }

  return float_to_string(L, precision) + units;
}

// C
function str_to_C(str_C) {
  let val = parse_value(str_C);
  let C = val[0];
  let k = 0;
  if (val[1].toLowerCase() == "f" || val[1].toLowerCase() == "") {
    k = 1;
  }
  else if (val[1].toLowerCase() == "m" || val[1].toLowerCase() == "mf") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "uf") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "nf") {
    k = 1e-9;
  }
  else if (val[1].toLowerCase() == "p" || val[1].toLowerCase() == "pf") {
    k = 1e-12;
  }


  if (k == 0) {
    throw "error parsing C: " + str_C;
  }

  C *= k;

  if (isNaN(C) || !isFinite(C)) {
    throw "error parsing C: " + str_C;
  }

  return C;
}

function C_to_str(C) {
  let units = "F";

  if (C == 0 || !isFinite(C) || isNaN(C)) {
    throw "error parsing C: " + C;
  }

  else if (C < fThr || C > baseThr) {
    return C.toExponential(precision) + "F";
  }
  else if (C < pThr) {
    C *= 1e12;
    units = "pF";
  }
  else if (C < nThr) {
    C *= 1e9;
    units = "nF";
  }
  /*
  else if (C < 1e-3 - 1e-10) {
    C *= 1e6;
    units = "uF";
  }
  else if (C < 1 - 1e-7) {
    C *= 1e3;
    units = "mF";
  }
  */
  else if (C < mThr) {
    C *= 1e6;
    units = "uF";
  }

  return float_to_string(C, precision) + units;
}

// Freq
function str_to_freq(str_freq) {
  let val = parse_value(str_freq);
  let f = val[0];
  let k = 0;
  if (val[1].toLowerCase() == "" || val[1].toLowerCase() == "h" || val[1].toLowerCase() == "hz") {
    k = 1;
  }
  else if (val[1].toLowerCase() == "k" || val[1].toLowerCase() == "kh" || val[1].toLowerCase() == "khz") {
    k = 1e3;
  }
  else if (val[1].toLowerCase() == "m" || val[1].toLowerCase() == "mh" || val[1].toLowerCase() == "mhz") {
    k = 1e6;
  }
  else if (val[1].toLowerCase() == "g" || val[1].toLowerCase() == "gh" || val[1].toLowerCase() == "ghz") {
    k = 1e9;
  }
  else if (val[1].toLowerCase() == "t" || val[1].toLowerCase() == "th" || val[1].toLowerCase() == "thz") {
    k = 1e12;
  }

  if (k == 0) {
    throw "error parsing freq: " + str_freq;
  }

  f *= k;

  if (isNaN(f) || !isFinite(f)) {
    throw "error parsing f: " + str_freq;
  }


  return f;
}

function freq_to_str(freq) {
  let units = "Hz";

  if (freq == 0 || !isFinite(freq) || isNaN(freq)) {
    throw "error parsing freq: " + freq;
  }

  else if (freq < uThr || freq > 1e15) {
    return freq.toExponential(precision) + "Hz";
  }
  else if (freq < baseThr) {
    units = "Hz";
  }
  else if (freq < kThr) {
    freq /= 1e3;
    units = "kHz";
  }
  else if (freq < MThr) {
    freq /= 1e6;
    units = "MHz";
  }
  else if (freq < GThr) {
    freq /= 1e9;
    units = "GHz";
  }
  else {
    freq /= 1e12;
    units = "THz";
  }

  return float_to_string(freq, precision) + units;
}

// R
function str_to_R(str_R) {
  let val = parse_value(str_R);
  let R = val[0];
  let k = 0;
  if (val[1].toLowerCase() == "r" || val[1] == "" || val[1].toLowerCase() == "ohm") {
    k = 1;
  }
  else if (val[1].toLowerCase() == "k" || val[1].toLowerCase() == "kohm") {
    k = 1e3;
  }
  else if (val[1].toLowerCase() == "g" || val[1].toLowerCase() == "gohm") {
    k = 1e9;
  }
  else if (val[1] == "M" || val[1] == "Mohm" || val[1] == "MOhm" || val[1].toLowerCase() == "meg") {
    k = 1e6;
  }
  else if (val[1] == "m" || val[1] == "mohm" || val[1] == "mOhm") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "uohm") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "nohm") {
    k = 1e-9;
  }
  else if (val[1].toLowerCase() == "p" || val[1].toLowerCase() == "pohm") {
    k = 1e-12;
  }

  if (k == 0) {
    throw "error parsing R: " + str_R;
  }

  R *= k;

  if (isNaN(R) || !isFinite(R)) {
    throw "error parsing R: " + str_R;
  }

  return R;
}

function R_to_str(R) {
  let units = "";

  if (R == 0 || !isFinite(R) || isNaN(R)) {
    throw "error parsing R: " + R;
  }

  else if (R > GThr || R < pThr) {
    return R.toExponential(precision) + "";
  }
  else if (R < nThr) {
    R *= 1e9;
    units = "n";
  }
  else if (R < uThr) {
    R *= 1e6;
    units = "u";
  }
  else if (R < baseThr) {
    units = "";
  }
  else if (R < kThr) {
    R /= 1e3;
    units = "k";
  }
  else if (R < MThr) {
    R /= 1e6;
    units = "M";
  }
  else {
    R /= 1e9;
    units = "G";
  }

  return float_to_string(R, precision) + units;
}

// Time
function str_to_t(str_t) {
  let val = parse_value(str_t);
  let t = val[0];
  let k = 0;
  if (val[1].toLowerCase() == "s" || val[1].toLowerCase() == "") {
    k = 1;
  }
  else if (val[1].toLowerCase() == "m" || val[1].toLowerCase() == "ms") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "us") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "ns") {
    k = 1e-9;
  }
  else if (val[1].toLowerCase() == "p" || val[1].toLowerCase() == "ps") {
    k = 1e-12;
  }

  if (k == 0) {
    throw "error parsing t: " + str_t;
  }

  t *= k;
  if (isNaN(t) || !isFinite(t)) {
    throw "error parsing t: " + str_t;
  }

  return t;
}

function t_to_str(t) {
  let units = "s";

  if (t == 0 || !isFinite(t) || isNaN(t)) {
    throw "error parsing t: " + t;
  }

  else if (t < fThr || t > kThr) {
    return t.toExponential(precision) + "s";
  }
  else if (t < pThr) {
    t *= 1e12;
    units = "ps";
  }
  else if (t < nThr) {
    t *= 1e9;
    units = "ns";
  }
  else if (t < uThr) {
    t *= 1e6;
    units = "us";
  }
  else if (t < mThr) {
    t *= 1e3;
    units = "ms";
  }

  return float_to_string(t, precision) + units;
}

// V
function str_to_V(str_V) {
  let val = parse_value(str_V);
  let V = val[0];
  let k = 0;

  if (val[1].toLowerCase() == "v" || val[1].toLowerCase() == "") {
    k = 1;
  }
  else if (val[1] == "m" || val[1] == "mv" || val[1] == "mV") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "uv") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "nv") {
    k = 1e-9;
  }
  else if (val[1].toLowerCase() == "p" || val[1].toLowerCase() == "pv") {
    k = 1e-12;
  }
  else if (val[1].toLowerCase() == "f" || val[1].toLowerCase() == "fv") {
    k = 1e-15;
  }
  else if (val[1].toLowerCase() == "k" || val[1].toLowerCase() == "kv") {
    k = 1e3;
  }
  else if (val[1] == "M" || val[1] == "Mv" || val[1] == "MV") {
    k = 1e6;
  }

  if (k == 0) {
    throw "error parsing V: " + str_V;
  }

  V *= k;

  if (isNaN(V) || !isFinite(V)) {
    throw "error parsing V: " + str_V;
  }

  return V;
}

function V_to_str(V) {
  let units = "V";

  if (V == 0 || !isFinite(V) || isNaN(V)) {
    throw "error parsing V: " + V;
  }

  else if (V < 1e-15 || V > MThr) {
    return V.toExponential(precision) + "V";
  }

  else if (V < fThr) {
    V *= 1e15;
    units = "fV";
  }
  else if (V < pThr) {
    V *= 1e12;
    units = "pV";
  }
  else if (V < nThr) {
    V *= 1e9;
    units = "nV";
  }
  else if (V < uThr) {
    V *= 1e6;
    units = "uV";
  }
  else if (V < mThr) {
    V *= 1e3;
    units = "mV";
  }
  else if (V < baseThr) {
    units = "V";
  }
  else if (V < 1e6) {
    V /= 1e3;
    units = "kV";
  }
  else {
    V /= 1e6;
    units = "MV";
  }

  return float_to_string(V, precision) + units;
}

// I
function str_to_I(str_I) {
  let val = parse_value(str_I);
  let I = val[0];
  let k = 0;

  if (val[1].toLowerCase() == "a" || val[1].toLowerCase() == "") {
    k = 1;
  }
  else if (val[1].toLowerCase() == "m" || val[1].toLowerCase() == "ma") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "ua") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "na") {
    k = 1e-9;
  }
  else if (val[1].toLowerCase() == "p" || val[1].toLowerCase() == "pa") {
    k = 1e-12;
  }
  else if (val[1].toLowerCase() == "f" || val[1].toLowerCase() == "fa") {
    k = 1e-15;
  }
  else if (val[1].toLowerCase() == "k" || val[1].toLowerCase() == "ka") {
    k = 1e3;
  }

  if (k == 0) {
    throw "error parsing I: " + str_I;
  }

  I *= k;
  if (isNaN(I) || !isFinite(I)) {
    throw "error parsing I: " + str_I;
  }

  return I;
}

function I_to_str(I) {
  let units = "A";

  if (I == 0 || !isFinite(I) || isNaN(I)) {
    throw "error parsing I: " + I;
  }

  else if (I < 1e-15 || I > MThr) {
    return I.toExponential(precision) + "A";
  }

  else if (I < fThr) {
    I *= 1e15;
    units = "fA";
  }
  else if (I < pThr) {
    I *= 1e12;
    units = "pA";
  }
  else if (I < nThr) {
    I *= 1e9;
    units = "nA";
  }
  else if (I < uThr) {
    I *= 1e6;
    units = "uA";
  }
  else if (I < mThr) {
    I *= 1e3;
    units = "mA";
  }
  else if (I < baseThr) {
    units = "A";
  }
  else if (I < kThr) {
    I /= 1e3;
    units = "kA";
  }
  else {
    I /= 1e6;
    units = "MA";
  }

  return float_to_string(I, precision) + units;
}

// P
function str_to_P(str_P) {
  let val = parse_value(str_P);
  let P = val[0];
  let k = 0;

  if (val[1].toLowerCase() == "w" || val[1].toLowerCase() == "") {
    k = 1;
  }
  else if (val[1] == "m" || val[1] == "mw" || val[1] == "mW") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "uw") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "nw") {
    k = 1e-9;
  }
  else if (val[1].toLowerCase() == "p" || val[1].toLowerCase() == "pw") {
    k = 1e-12;
  }
  else if (val[1].toLowerCase() == "k" || val[1].toLowerCase() == "kw") {
    k = 1e3;
  }
  else if (val[1] == "M" || val[1] == "MW" || val[1] == "Mw") {
    k = 1e6;
  }

  if (k == 0) {
    throw "error parsing P: " + str_P;
  }

  P *= k;

  if (isNaN(P) || !isFinite(P)) {
    throw "error parsing P: " + str_P;
  }


  return P;
}

function P_to_str(P) {
  let units = "W";

  if (P == 0 || !isFinite(P) || isNaN(P)) {
    throw "error parsing P: " + P;
  }

  else if (P < fThr || P > MThr) {
    return P.toExponential(precision) + "W";
  }

  else if (P < pThr) {
    P *= 1e12;
    units = "pW";
  }
  else if (P < nThr) {
    P *= 1e9;
    units = "nW";
  }
  else if (P < uThr) {
    P *= 1e6;
    units = "uW";
  }
  else if (P < mThr) {
    P *= 1e3;
    units = "mW";
  }
  else if (P < baseThr) {
    units = "W";
  }
  else if (P < kThr) {
    P /= 1e3;
    units = "kW";
  }
  else {
    P /= 1e6;
    units = "MW";
  }

  return float_to_string(P, precision) + units;
}

// Length
function str_to_len(str_len) {
  let val = parse_value(str_len);
  let len = val[0];
  let k = 0;
  if (val[1].toLowerCase() == "m" || val[1].toLowerCase() == "") {
    k = 1;
  }
  else if (val[1].toLowerCase() == "in") {
    k = 1;
    len *= 0.0254;
  }
  else if (val[1].toLowerCase() == "ft" || val[1].toLowerCase() == "f" || val[1].toLowerCase() == "foot" || val[1].toLowerCase() == "feet") {
    k = 1;
    len *= 0.3048;
  }
  else if (val[1].toLowerCase() == "mi" || val[1].toLowerCase() == "mile" || val[1].toLowerCase() == "miles" || val[1].toLowerCase() == "mil") {
    k = 1;
    len *= 1609.34;
  }
  else if (val[1].toLowerCase() == "cm") {
    k = 1e-2;
  }
  else if (val[1].toLowerCase() == "mm") {
    k = 1e-3;
  }
  else if (val[1].toLowerCase() == "u" || val[1].toLowerCase() == "um") {
    k = 1e-6;
  }
  else if (val[1].toLowerCase() == "n" || val[1].toLowerCase() == "nm") {
    k = 1e-9;
  }
  else if (val[1].toLowerCase() == "k" || val[1].toLowerCase() == "km") {
    k = 1e3;
  }

  if (k == 0) {
    throw "error parsing length: " + str_len;
  }

  len *= k;

  if (isNaN(len) || !isFinite(len)) {
    throw "error parsing length: " + str_len;
  }


  return len;
}

function len_to_str(len) {
  let units = "m";

  if (len == 0 || !isFinite(len) || isNaN(len)) {
    throw "error parsing len: " + len;
  }

  else if (len < 1e-9 || len > 1e9) {
    return len.toExponential(precision) + "m";
  }

  else if (len < 1e-6) {
    len *= 1e9;
    units = "nm";
  }
  else if (len < 1e-3) {
    len *= 1e6;
    units = "um";
  }
  else if (len < 0.01) {
    len *= 1e3;
    units = "mm";
  }
  else if (len < 1) {
    len *= 1e2;
    units = "cm";
  }
  else if (len < 1e3) {
    units = "m";
  }
  else {
    units = "km";
    len /= 1e3;
  }

  return float_to_string(len, precision) + units;
}


///////////////////////////////////////////////////////
function ohms_law() {
  var str_V = document.getElementById('form-ohm-V').value;
  var str_R = document.getElementById('form-ohm-R').value;
  var str_I = document.getElementById('form-ohm-I').value;
  var str_P = document.getElementById('form-ohm-P').value;

  try {
    let V = 0;
    let R = 0;
    let I = 0;
    let P = 0;
    let nparam = 0;
    if (str_V.length > 0) {
      V = str_to_V(str_V);
      ++nparam;
    }
    if (str_R.length > 0) {
      R = str_to_R(str_R);
      ++nparam;
    }
    if (str_I.length > 0) {
      I = str_to_I(str_I);
      ++nparam;
    }
    if (str_P.length > 0) {
      P = str_to_P(str_P);
      ++nparam;
    }

    if (nparam == 2) {
      if (V != 0 && R != 0) {
        I = V / R;
        str_I = I_to_str(I);
        P = I * V;
        str_P = P_to_str(P);
        document.getElementById('form-ohm-I').value = str_I;
        document.getElementById('form-ohm-P').value = str_P;
      }
      else if (V != 0 && I != 0) {
        R = V / I;
        str_R = R_to_str(R);
        document.getElementById('form-ohm-R').value = str_R;

        P = V * I;
        str_P = P_to_str(P);
        document.getElementById('form-ohm-P').value = str_P;
      }
      else if (I != 0 && R != 0) {
        V = I * R;
        str_V = V_to_str(V);
        document.getElementById('form-ohm-V').value = str_V;

        P = V * I;
        str_P = P_to_str(P);
        document.getElementById('form-ohm-P').value = str_P;
      }
      else if (P != 0 && R != 0) {
        V = Math.sqrt(P * R);
        str_V = V_to_str(V);
        document.getElementById('form-ohm-V').value = str_V;

        I = V / R;
        str_I = I_to_str(I);
        document.getElementById('form-ohm-I').value = str_I;
      }
      else if (P != 0 && I != 0) {
        V = P / I;
        str_V = V_to_str(V);

        document.getElementById('form-ohm-V').value = str_V;

        R = V / I;
        str_R = R_to_str(R);
        document.getElementById('form-ohm-R').value = str_R;
      }
      else if (P != 0 && V != 0) {
        R = V * V / P;
        str_R = R_to_str(R);
        document.getElementById('form-ohm-R').value = str_R;

        I = V / R;
        str_I = I_to_str(I);
        document.getElementById('form-ohm-I').value = str_I;
      }
    }
    else {
      reportError("wrong number of input fields");
    }

  }
  catch (err) {
    reportError(err);
  }


}

function calc_Xl() {
  var str_L = document.getElementById('form-Xl-L').value;
  var str_freq = document.getElementById('form-Xl-freq').value;
  var str_R = document.getElementById('form-Xl-Xl').value;

  try {
    let L = 0;
    let freq = 0;
    let R = 0;
    let nparam = 0;
    if (str_L.length > 0) {
      L = str_to_L(str_L);
      ++nparam;
    }
    if (str_freq.length > 0) {
      freq = str_to_freq(str_freq);
      ++nparam;
    }
    if (str_R.length > 0) {
      R = str_to_R(str_R);
      ++nparam;
    }

    if (nparam == 2) {
      if (L != 0 && freq != 0) {
        R = 2 * Math.PI * freq * L;
        str_R = R_to_str(R);
        document.getElementById('form-Xl-Xl').value = str_R;
      }
      else if (L != 0 && R != 0) {
        freq = R / (2 * Math.PI * L);
        str_freq = freq_to_str(freq);
        document.getElementById('form-Xl-freq').value = str_freq;
      }
      else {
        L = R / (2 * Math.PI * freq);
        str_L = L_to_str(L);
        document.getElementById('form-Xl-L').value = str_L;
      }
    }
    else {
      throw "wrong number of parameters";
    }

  }
  catch (err) {
    reportError(err);
  }

}

function calc_Xc() {
  let str_C = document.getElementById('form-Xc-C').value;
  let str_freq = document.getElementById('form-Xc-freq').value;
  let str_R = document.getElementById('form-Xc-Xc').value;

  try {
    let C = 0;
    let freq = 0;
    let R = 0;
    let nparam = 0;
    if (str_C.length > 0) {
      C = str_to_C(str_C);
      ++nparam;
    }
    if (str_freq.length > 0) {
      freq = str_to_freq(str_freq);
      ++nparam;
    }
    if (str_R.length > 0) {
      R = str_to_R(str_R);
      ++nparam;
    }

    if (nparam == 2) {
      if (C != 0 && freq != 0) {
        R = 1 / (2 * Math.PI * freq * C);
        str_R = R_to_str(R);
        document.getElementById('form-Xc-Xc').value = str_R;
      }
      else if (C != 0 && R != 0) {
        freq = 1 / (2 * Math.PI * R * C);
        str_freq = freq_to_str(freq);
        document.getElementById('form-Xc-freq').value = str_freq;
      }
      else {
        C = 1 / (2 * Math.PI * freq * R);
        str_C = C_to_str(C);
        document.getElementById('form-Xc-C').value = str_C;
      }
    }
    else {
      throw "wrong number of parameters";
    }

  }
  catch (err) {
    reportError(err);
  }

}

function RC_calc_freq(t) {
  let freq = 1 / (2 * Math.PI * t);
  let str_freq = freq_to_str(freq);
  document.getElementById('form-RC-freq').value = str_freq;
  return freq;
}

function RC_calc_t(R, C) {
  let t = R * C;
  let str_t = t_to_str(t);
  document.getElementById('form-RC-t').value = str_t;
  return t;
}

function RC_calc_C(freq, R) {
  let C = 1 / (2 * Math.PI * freq * R);
  let str_C = C_to_str(C);
  document.getElementById('form-RC-C').value = str_C;
  return C;
}

function RC_calc_R(freq, C) {
  let R = 1 / (2 * Math.PI * freq * C);
  let str_R = R_to_str(R);
  document.getElementById('form-RC-R').value = str_R;
  return R;
}

function calc_cutoff_freq() {
  let str_R = document.getElementById('form-RC-R').value;
  let str_C = document.getElementById('form-RC-C').value;
  let str_freq = document.getElementById('form-RC-freq').value;
  let str_t = document.getElementById('form-RC-t').value;

  try {
    let R = 0;
    let C = 0;
    let freq = 0;
    let t = 0;
    let nparam = 0;
    if (str_R.length > 0) {
      R = str_to_R(str_R);
      ++nparam;
    }
    if (str_C.length > 0) {
      C = str_to_C(str_C);
      ++nparam;
    }
    if (str_freq.length > 0) {
      freq = str_to_freq(str_freq);
      ++nparam;
    }
    if (str_t.length > 0) {
      t = str_to_t(str_t);
      ++nparam;
    }

    if (nparam == 2 && (C != 0 || R != 0)) {
      if (R != 0 && C != 0) {
        t = RC_calc_t(R, C);
        RC_calc_freq(t);
      }
      else if (freq != 0 && R != 0) {
        C = RC_calc_C(freq, R);
        RC_calc_t(R, C);
      }
      else if (freq != 0 && C != 0) {
        R = RC_calc_R(freq, C);
        RC_calc_t(R, C);
      }
      else if (t != 0 && R != 0) {
        freq = RC_calc_freq(t);
        RC_calc_C(freq, R);
      }
      else if (t != 0 && C != 0) {
        freq = RC_calc_freq(t);
        RC_calc_R(freq, C);
      }
      else {
        throw "invalid input"
      }
    }
    else {
      throw "invalid input"
    }

  }
  catch (err) {
    reportError(err);
  }

}

function time_freq_conv(target) {

  let str_t = document.getElementById('form-tf-t').value;
  let str_f = document.getElementById('form-tf-f').value;

  try {
    let f = 0;
    let t = 0;
    if (str_f.length > 0) {
      f = str_to_freq(str_f);
    }
    if (str_t.length > 0) {
      t = str_to_t(str_t);
    }

    if (target == "form-tf-t" && t != 0) {
      f = 0;
    }
    else if (target == "form-tf-f" && f != 0) {
      t = 0;
    }

    if (f != 0 && t == 0) {
      t = 1 / f;
      str_t = t_to_str(t);
      document.getElementById('form-tf-t').value = str_t;
    }
    else if (f == 0 && t != 0) {
      f = 1 / t;
      str_f = freq_to_str(f);
      document.getElementById('form-tf-f').value = str_f;
    }
    else {
      throw "invalid input";
    }

  }
  catch (err) {
    reportError(err);
  }
}

function freq_wl_conv(target) {
  let str_f = document.getElementById('form-fw-f').value;
  let str_wl = document.getElementById('form-fw-wl').value;

  try {
    let c = 3e+8;
    let f = 0;
    let wl = 0;
    if (str_f.length > 0) {
      f = str_to_freq(str_f);
    }
    if (str_wl.length > 0) {
      wl = str_to_len(str_wl);
    }

    if (target == "form-fw-wl" && wl != 0) {
      f = 0;
    }
    else if (target == "form-fw-f" && f != 0) {
      wl = 0;
    }

    if (f != 0 && wl == 0) {
      wl = c / f;
      str_wl = len_to_str(wl);
      document.getElementById('form-fw-wl').value = str_wl;
    }
    else if (f == 0 && wl != 0) {
      f = c / wl;
      if (f >= 1) {
        str_f = freq_to_str(f);
        document.getElementById('form-fw-f').value = str_f;
      }
    }
    else {
      throw "invalid input"
    }

  }
  catch (err) {
    reportError(err)
  }

}

function rlc_calc_Qs(L, R, freq) {
  let Qs = 2 * Math.PI * freq * L / R;
  let str_Qs = float_to_string(Qs);
  document.getElementById('form-RLC-Qs').value = str_Qs;
}

function rlc_calc_Qp(L, R, freq) {
  let Qp = R / (2 * Math.PI * freq * L);
  let str_Qp = float_to_string(Qp);
  document.getElementById('form-RLC-Qp').value = str_Qp;
}

function calc_Q(L, R, freq, Qs, Qp) {
  if (L > 1e-15 && freq > 1e-15) {
    if (R > 0 && Qs == 0 && Qp == 0) {
      rlc_calc_Qs(L, R, freq);
      rlc_calc_Qp(L, R, freq);
    }
    else if (Qs > 0 && R == 0 && Qp == 0) {
      R = (2 * Math.PI * freq * L) / Qs;
      let str_R = R_to_str(R);
      document.getElementById('form-RLC-R').value = str_R;
      rlc_calc_Qp(L, R, freq);
    }
    else if (Qp > 0 && R == 0 && Qs == 0) {
      R = Qp * (2 * Math.PI * freq * L);
      let str_R = R_to_str(R);
      document.getElementById('form-RLC-R').value = str_R;
      rlc_calc_Qs(L, R, freq);
    }
  }
}

function rlc_calc() {
  let str_R = document.getElementById('form-RLC-R').value;
  let str_L = document.getElementById('form-RLC-L').value;
  let str_C = document.getElementById('form-RLC-C').value;
  let str_freq = document.getElementById('form-RLC-freq').value;
  let str_Qs = document.getElementById('form-RLC-Qs').value;
  let str_Qp = document.getElementById('form-RLC-Qp').value;

  try {
    let nparam = 0;
    let R = 0;
    let L = 0;
    let C = 0;
    let freq = 0;
    let Qs = 0;
    let Qp = 0;

    if (str_R.length > 0) {
      R = str_to_R(str_R);
      ++nparam;
    }

    if (str_L.length > 0) {
      L = str_to_L(str_L);
      ++nparam;
    }

    if (str_C.length > 0) {
      C = str_to_C(str_C);
      ++nparam;
    }

    if (str_freq.length > 0) {
      freq = str_to_freq(str_freq);
      ++nparam;
    }

    if (str_Qs.length > 0) {
      Qs = parse_float(str_Qs);
      ++nparam;
    }

    if (str_Qp.length > 0) {
      Qp = parse_float(str_Qp);
      ++nparam;
    }

    if (nparam == 2 || nparam == 3) {
      if (L != 0 && C != 0) {

        if (freq == 0) {
          freq = 1 / (2 * Math.PI * Math.sqrt(L * C));
          str_freq = freq_to_str(freq);
          if (freq > 0) {
            document.getElementById('form-RLC-freq').value = str_freq;
            calc_Q(L, R, freq, Qs, Qp);
          }
        }
      }
      else if (C != 0 && freq != 0) {
        L = 1 / (C * Math.pow(2 * Math.PI * freq, 2));
        str_L = L_to_str(L);
        document.getElementById('form-RLC-L').value = str_L;
        calc_Q(L, R, freq, Qs, Qp);
      }
      else if (L != 0 && freq != 0) {
        C = 1 / (L * Math.pow(2 * Math.PI * freq, 2));
        str_C = C_to_str(C);
        document.getElementById('form-RLC-C').value = str_C;
        calc_Q(L, R, freq, Qs, Qp);
      }
      else if (R > 0 && freq > 0 && Qs > 0) {
        L = Qs * R / (2 * Math.PI * freq);
        str_L = L_to_str(L);
        document.getElementById('form-RLC-L').value = str_L;
        Qp = 1 / Qs;
        str_Qp = float_to_string(Qp);
        document.getElementById('form-RLC-Qp').value = str_Qp;
        C = 1 / (L * Math.pow(2 * Math.PI * freq, 2));
        str_C = C_to_str(C);
        document.getElementById('form-RLC-C').value = str_C;
      }
      else if (R > 0 && freq > 0 && Qp > 0) {
        L = R / (Qp * 2 * Math.PI * freq);
        str_L = L_to_str(L);
        document.getElementById('form-RLC-L').value = str_L;
        Qs = 1 / Qp;
        str_Qs = float_to_string(Qs);
        document.getElementById('form-RLC-Qs').value = str_Qs;
        C = 1 / (L * Math.pow(2 * Math.PI * freq, 2));
        str_C = C_to_str(C);
        document.getElementById('form-RLC-C').value = str_C;
      }
      else if (R > 0 && L > 0 && Qs > 0) {
        freq = Qs * R / (2 * Math.PI * L);
        str_freq = freq_to_str(freq);
        document.getElementById('form-RLC-freq').value = str_freq;
        Qp = 1 / Qs;
        str_Qp = float_to_string(Qp);
        document.getElementById('form-RLC-Qp').value = str_Qp;
        C = 1 / (L * Math.pow(2 * Math.PI * freq, 2));
        str_C = C_to_str(C);
        document.getElementById('form-RLC-C').value = str_C;
      }
      else if (R > 0 && L > 0 && Qp > 0) {
        freq = R / (2 * Math.PI * L * Qp);
        str_freq = freq_to_str(freq);
        document.getElementById('form-RLC-freq').value = str_freq;
        Qs = 1 / Qp;
        str_Qs = float_to_string(Qs);
        document.getElementById('form-RLC-Qs').value = str_Qs;
        C = 1 / (L * Math.pow(2 * Math.PI * freq, 2));
        str_C = C_to_str(C);
        document.getElementById('form-RLC-C').value = str_C;
      }
      else {
        throw "invalid input"
      }

    }
    else {
      throw "invalid number of parameters"
    }

  }
  catch (err) {
    reportError(err)
  }
}

function dbm_calc(target) {
  let str_P = document.getElementById('form-dbm-P').value;
  let str_dbm = document.getElementById('form-dbm-dbm').value;
  let str_Vrms = document.getElementById('form-dbm-Vrms').value;
  let str_Vpk = document.getElementById('form-dbm-Vpk').value;
  let str_Vpp = document.getElementById('form-dbm-Vpp').value;

  let nparam = 0;
  let Vrms = 0;
  let Vpk = 0;
  let Vpp = 0;
  let P = 0;
  let dbm = 0;

  try {
    if (str_P.length > 0) {
      P = str_to_P(str_P);
      ++nparam;
    }
    if (str_dbm.length > 0) {
      dbm = parse_float (str_dbm, true);
      ++nparam;
    }
    if (str_Vrms.length > 0) {
      Vrms = str_to_V(str_Vrms);
      ++nparam;
    }
    if (str_Vpk.length > 0) {
      Vpk = str_to_V(str_Vpk);
      ++nparam;
    }
    if (str_Vpp.length > 0) {
      Vpp = str_to_V(str_Vpp);
      ++nparam;
    }

    if (target == "form-dbm-P" && P != 0) {
      dbm = Vrms = Vpk = Vpp = 0;
      nparam = 1;
    }
    else if (target == "form-dbm-dbm" && dbm != 0) {
      P = Vrms = Vpk = Vpp = 0;
      nparam = 1;
    }
    else if (target == "form-dbm-Vrms" && Vrms != 0) {
      dbm = P = Vpk = Vpp = 0;
      nparam = 1;
    }
    else if (target == "form-dbm-Vpk" && Vpk != 0) {
      dbm = P = Vrms = Vpp = 0;
      nparam = 1;
    }
    else if (target == "form-dbm-Vpp" && Vpp != 0) {
      dbm = P = Vrms = Vpk = 0;
      nparam = 1;
    }

    if (nparam == 1) {
      if (P > 0) {
        dbm = 10 * Math.log10(P * 1000);
        str_dbm = float_to_string(dbm);
        document.getElementById('form-dbm-dbm').value = str_dbm;
        Vrms = Math.sqrt(P * 50);
        str_Vrms = V_to_str(Vrms);
        document.getElementById('form-dbm-Vrms').value = str_Vrms;
        Vpk = Vrms * Math.sqrt(2);
        str_Vpk = V_to_str(Vpk);
        document.getElementById('form-dbm-Vpk').value = str_Vpk;
        Vpp = 2 * Vpk;
        str_Vpp = V_to_str(Vpp);
        document.getElementById('form-dbm-Vpp').value = str_Vpp;

      }
      else if (dbm != 0) {
        P = 0.001 * Math.pow(10, dbm / 10);
        str_P = P_to_str(P);
        document.getElementById('form-dbm-P').value = str_P;
        Vrms = Math.sqrt(P * 50);
        str_Vrms = V_to_str(Vrms);
        document.getElementById('form-dbm-Vrms').value = str_Vrms;
        Vpk = Vrms * Math.sqrt(2);
        str_Vpk = V_to_str(Vpk);
        document.getElementById('form-dbm-Vpk').value = str_Vpk;
        Vpp = 2 * Vpk;
        str_Vpp = V_to_str(Vpp);
        document.getElementById('form-dbm-Vpp').value = str_Vpp;
      }
      else if (Vrms > 0) {
        P = Vrms * Vrms / 50;
        str_P = P_to_str(P);
        document.getElementById('form-dbm-P').value = str_P;
        dbm = 10 * Math.log10(P * 1000);
        str_dbm = float_to_string(dbm);
        document.getElementById('form-dbm-dbm').value = str_dbm;
        Vpk = Vrms * Math.sqrt(2);
        str_Vpk = V_to_str(Vpk);
        document.getElementById('form-dbm-Vpk').value = str_Vpk;
        Vpp = 2 * Vpk;
        str_Vpp = V_to_str(Vpp);
        document.getElementById('form-dbm-Vpp').value = str_Vpp;
      }
      else if (Vpk > 0) {
        Vrms = Vpk / Math.sqrt(2);
        str_Vrms = V_to_str(Vrms);
        document.getElementById('form-dbm-Vrms').value = str_Vrms;
        P = Vrms * Vrms / 50;
        str_P = P_to_str(P);
        document.getElementById('form-dbm-P').value = str_P;
        dbm = 10 * Math.log10(P * 1000);
        str_dbm = float_to_string(dbm);
        document.getElementById('form-dbm-dbm').value = str_dbm;
        Vpp = 2 * Vpk;
        str_Vpp = V_to_str(Vpp);
        document.getElementById('form-dbm-Vpp').value = str_Vpp;
      }
      else if (Vpp > 0) {
        Vpk = Vpp / 2;
        str_Vpk = V_to_str(Vpk);
        document.getElementById('form-dbm-Vpk').value = str_Vpk;
        Vrms = Vpk / Math.sqrt(2);
        str_Vrms = V_to_str(Vrms);
        document.getElementById('form-dbm-Vrms').value = str_Vrms;
        P = Vrms * Vrms / 50;
        str_P = P_to_str(P);
        document.getElementById('form-dbm-P').value = str_P;
        dbm = 10 * Math.log10(P * 1000);
        str_dbm = float_to_string(dbm);
        document.getElementById('form-dbm-dbm').value = str_dbm;
      }
      else {
        throw "invalid input";
      }
    }
    else {
      throw "invalid number of parameters";
    }

  }
  catch (err) {
    reportError(err);
  }
}

function ripple_calc() {

  let nparam = 0;
  let f = 0;
  let C = 0;
  let I = 0;
  let V = 0;

  try {
    let str_f = document.getElementById('form-ripple-f').value;
    let str_C = document.getElementById('form-ripple-C').value;
    let str_I = document.getElementById('form-ripple-I').value;
    let str_V = document.getElementById('form-ripple-V').value;

    if (str_f.length > 0) {
      f = str_to_freq(str_f);
      ++nparam;
    }
    if (str_C.length > 0) {
      C = str_to_C(str_C);
      ++nparam;
    }
    if (str_I.length > 0) {
      I = str_to_I(str_I);
      ++nparam;
    }
    if (str_V.length > 0) {
      V = str_to_V(str_V);
      ++nparam;
    }

    if (nparam == 3) {
      if (V == 0) {
        V = I / (4 * f * C);
        str_V = V_to_str(V);
        document.getElementById('form-ripple-V').value = str_V;
      }
      else if (I == 0) {
        I = V * 4 * f * C;
        str_I = I_to_str(I);
        document.getElementById('form-ripple-I').value = str_I;
      }
      else if (C == 0) {
        C = I / (4 * f * V);
        str_C = C_to_str(C);
        document.getElementById('form-ripple-C').value = str_C;
      }
      else if (f == 0) {
        f = I  / (C * 4 * V);
        str_f = freq_to_str(f);
        document.getElementById('form-ripple-f').value = str_f;
      }
      else {
        throw "invalid parameters"
      }
    }
    else {
      throw "invalid number of parameters"
    }

  }
  catch (err) {
    reportError(err)
  }

}

function headphone_calc() {
  let dbmw = 0;
  let dbv = 0;
  let R = 0;
  let I = 0;
  let V = 0;
  let P = 0;
  let L_db = 0;
  let n_ohm = 0;

  try {
    let str_Sdbmw = document.getElementById('form-headphone-sensitivity-dbmw').value;
    let str_Sdbv = document.getElementById('form-headphone-sensitivity-dbv').value;
    let str_I = document.getElementById('form-headphone-I').value;
    let str_R = document.getElementById('form-headphone-R').value;
    let str_V = document.getElementById('form-headphone-V').value;
    let str_P = document.getElementById('form-headphone-P').value;
    let str_L_db = document.getElementById('form-headphone-loudness').value;

    if (str_Sdbmw.length > 0) {
      dbmw = Number.parseFloat(str_Sdbmw);
    }
    if (str_Sdbv.length > 0) {
      dbv = Number.parseFloat(str_Sdbv);
    }
    if (str_I.length > 0) {
      I = str_to_I(str_I);
      ++n_ohm;
    }
    if (str_V.length > 0) {
      V = str_to_V(str_V);
      ++n_ohm;
    }
    if (str_P.length > 0) {
      P = str_to_P(str_P);
      ++n_ohm;
    }
    if (str_R.length > 0) {
      R = str_to_R(str_R);
      ++n_ohm;
    }

    if (str_L_db.length > 0) {
      L_db = Number.parseFloat(str_L_db);
    }

    if (dbmw != 0 && R != 0) {
      dbv = dbmw - 10 * Math.log10(R / 1000);
      document.getElementById('form-headphone-sensitivity-dbv').value = float_to_string (dbv, 3);
    }
    else if (dbv != 0 && R != 0) {
      dbmw = dbv + 10 * Math.log10(R / 1000);
      document.getElementById('form-headphone-sensitivity-dbmw').value = float_to_string(dbmw, 3);
    }

    if (L_db != 0 && P == 0 && dbmw != 0 && R != 0) {
      P = Math.pow(10, (L_db - dbmw) / 10) / 1000;
      str_P = P_to_str(P);
      document.getElementById('form-headphone-P').value = str_P;
      ++n_ohm;
    }

    if (n_ohm == 2) {
      if (V != 0 && R != 0) {
        I = V / R;
        str_I = I_to_str(I);
        document.getElementById('form-headphone-I').value = str_I;

        P = I * V;
        str_P = P_to_str(P);
        document.getElementById('form-headphone-P').value = str_P;
      }
      else if (V != 0 && I != 0) {
        R = V / I;
        str_R = R_to_str(R);
        document.getElementById('form-headphone-R').value = str_R;

        P = V * I;
        str_P = P_to_str(P);
        document.getElementById('form-headphone-P').value = str_P;
      }
      else if (I != 0 && R != 0) {
        V = I * R;
        str_V = V_to_str(V);
        document.getElementById('form-headphone-V').value = str_V;

        P = V * I;
        str_P = P_to_str(P);
        document.getElementById('form-headphone-P').value = str_P;
      }
      else if (P != 0 && R != 0) {
        V = Math.sqrt(P * R);
        str_V = V_to_str(V);
        document.getElementById('form-headphone-V').value = str_V;

        I = V / R;
        str_I = I_to_str(I);
        document.getElementById('form-headphone-I').value = str_I;
      }
      else if (P != 0 && I != 0) {
        V = P / I;
        str_V = V_to_str(V);

        document.getElementById('form-headphone-V').value = str_V;

        R = V / I;
        str_R = R_to_str(R);
        document.getElementById('form-headphone-R').value = str_R;
      }
      else if (P != 0 && V != 0) {
        R = V * V / P;
        str_R = R_to_str(R);
        document.getElementById('form-headphone-R').value = str_R;

        I = V / R;
        str_I = I_to_str(I);
        document.getElementById('form-headphone-I').value = str_I;
      }
      else {
        throw "invalid parameters"
      }
    }
    else {
      throw "invalid number of parameters"
    }

    if (L_db == 0 && P != 0 && dbmw != 0) {
      L_db = dbmw + 10 * Math.log10(P * 1000);
      str_L_db = float_to_string (L_db, 3);
      document.getElementById('form-headphone-loudness').value = str_L_db;
    }
    else if (P != 0 && dbmw == 0 && dbv == 0 && L_db != 0) {
      dbmw = L_db - 10 * Math.log10(P * 1000);
      str_Sdbmw = float_to_string (dbmw, 3);
      document.getElementById('form-headphone-sensitivity-dbmw').value = float_to_string (dbmw, 3);
      dbv = dbmw - 10 * Math.log10(R / 1000);
      document.getElementById('form-headphone-sensitivity-dbv').value = float_to_string (dbv, 3);
    }
    
  }
  catch (err) {
    reportError(err);
  }
}

function sound_calc(target) {
  let db = 0;
  let V = 0;
  let P = 0;
  let L = 0;

  try {
    let str_db = document.getElementById('form-sound-db').value;
    let str_V = document.getElementById('form-sound-V').value;
    let str_P = document.getElementById('form-sound-P').value;
    let str_L = document.getElementById('form-sound-L').value;

    if (str_db.length > 0) {
      db = parse_float(str_db, true);
      if (db > 1000) {
        db = 1000;
        document.getElementById('form-sound-db').value = "1000";
      }
      else if (db < -1000) {
        db = -1000;
        document.getElementById('form-sound-db').value = "1000";
      }
    }
    if (str_V.length > 0) {
      V = parse_float(str_V);
    }
    if (str_P.length > 0) {
      P = parse_float(str_P);
    }
    if (str_L.length > 0) {
      L = parse_float(str_L);
    }

    if (target == "form-sound-L-db" && str_db.length > 0) {
      V = P = L = 0;
    }
    else if (target == "form-sound-V" && V > 0) {
      P = L = 0;
      str_db = "";
    }
    else if (target == "form-sound-P" && P > 0) {
      V = L = 0;
      str_db = "";
    }
    else if (target == "form-sound-L" && L > 0) {
      V = P = 0;
      str_db = "";
    }

    const precision = 3;
    if (str_db.length > 0) {
      V = Math.pow(10, db / 20);
      document.getElementById('form-sound-V').value = float_to_string(V, precision);
      P = Math.pow(10, db / 10);
      document.getElementById('form-sound-P').value = float_to_string(P, precision);
      L = Math.pow(2, db / 10);
      document.getElementById('form-sound-L').value = float_to_string(L, precision);
    }
    else if (V > 0) {
      db = 20 * Math.log10(V);
      str_db = float_to_string (db, precision);
      document.getElementById('form-sound-db').value = str_db;
      P = Math.pow(10, db / 10);
      document.getElementById('form-sound-P').value = float_to_string(P, precision);
      L = Math.pow(2, db / 10);
      document.getElementById('form-sound-L').value = float_to_string(L, precision);
    }
    else if (P > 0) {
      db = 10 * Math.log10(P);
      str_db = float_to_string (db, precision);
      document.getElementById('form-sound-db').value = str_db;
      V = Math.pow(10, db / 20);
      document.getElementById('form-sound-V').value = float_to_string(V, precision);
      L = Math.pow(2, db / 10);
      document.getElementById('form-sound-L').value = float_to_string(L, precision);
    }
    else if (L > 0) {
      db = 10 * Math.log2(L);
      str_db = float_to_string (db, precision);
      document.getElementById('form-sound-db').value = str_db;
      V = Math.pow(10, db / 20);
      document.getElementById('form-sound-V').value = float_to_string(V, precision);
      P = Math.pow(10, db / 10);
      document.getElementById('form-sound-P').value = float_to_string(P, precision);
    }
    else {
      throw "invalid parameters"
    }

  }
  catch (err) {
    reportError(err);
  }

}

function tl_calc_t_VF(C, L, len) {
  let t0 = Math.sqrt(L * C);
  let t = t0 * len;
  let str_t = t_to_str(t);
  document.getElementById('form-tl-t').value = str_t;

  VF = 100 / (Vc * t0);
  document.getElementById('form-tl-VF').value = float_to_string(VF, 3);
}

function tl_calc(target) {
  let Zo = 0;
  let t = 0;
  let C = 0;
  let L = 0;
  let len = 1;
  let VF = 0;

  try {
    let str_Zo = document.getElementById('form-tl-Zo').value;
    let str_C = document.getElementById('form-tl-C').value;
    let str_L = document.getElementById('form-tl-L').value;
    let str_t = document.getElementById('form-tl-t').value;
    let str_VF = document.getElementById('form-tl-VF').value;
    let str_len = document.getElementById('form-tl-len').value;

    if (str_Zo.length > 0) {
      Zo = str_to_R(str_Zo);
    }
    if (str_C.length > 0) {
      C = str_to_C(str_C);
    }
    if (str_L.length > 0) {
      L = str_to_L(str_L);
    }
    if (str_t.length > 0) {
      t = str_to_t(str_t);
    }
    if (str_VF.length > 0) {
      VF = parse_float(str_VF);
    }

    if (str_len.length > 0) {
      len = str_to_len(str_len);
    }
    else {
      len = 1;
      document.getElementById('form-tl-len').value = "1m";
    }

    if (Zo == 0) {
      Zo = tc_default_Zo;
      document.getElementById('form-tl-Zo').value = R_to_str(Zo);
    }

    tc_default_Zo = Zo;

    let Cmin = 1 / (Vc * Zo);
    let Lmin = Zo / Vc;

    if (C != 0) {
      if (C < Cmin) {
        C = Cmin;
        str_C = C_to_str(C);
        document.getElementById('form-tl-C').value = str_C;
      }
      let L = Zo * Zo * C;
      let str_L = L_to_str(L);
      document.getElementById('form-tl-L').value = str_L;
      if (t == 0) {
        tl_calc_t_VF(C, L, len);
      }
      else {
        let t0 = Math.sqrt(L * C);
        len = t / t0;
        str_len = len_to_str(len);        
        document.getElementById('form-tl-len').value = str_len;
        VF = 100 / (Vc * t0);
        document.getElementById('form-tl-VF').value = float_to_string(VF, 3);
      }
    }
    else if (L != 0) {
      if (L < Lmin) {
        L = Lmin;
        str_L = L_to_str(L);
        document.getElementById('form-tl-L').value = str_L;
      }
      C = L / Zo / Zo;
      str_C = C_to_str(C);
      document.getElementById('form-tl-C').value = str_C;
      if (t == 0) {
        tl_calc_t_VF(C, L, len);
      }
      else {
        let t0 = Math.sqrt(L * C);
        len = t / t0;
        str_len = len_to_str(len);        
        document.getElementById('form-tl-len').value = str_len;
        VF = 100 / (Vc * t0);
        document.getElementById('form-tl-VF').value = float_to_string(VF, 3);
      }
    }
    else if (VF > 0) {
      if (VF > 100) {
        VF = 100;
        document.getElementById('form-tl-VF').value = "100";
      }
      let t0 = 100 / (VF * Vc);
      if (t == 0) {
        t = t0 * len;
        str_t = t_to_str(t);
        document.getElementById('form-tl-t').value = str_t;
      }
      else {
        len = t / t0;
        str_len = len_to_str(len);        
        document.getElementById('form-tl-len').value = str_len;
      }

      C = t0 / Zo;
      L = t0 * Zo;
      str_C = C_to_str(C);
      str_L = L_to_str(L);
      document.getElementById('form-tl-C').value = str_C;
      document.getElementById('form-tl-L').value = str_L;
    }
    else if (t > 0) {
      let t0 = t / len;
      if (t0 < 1 / Vc) {
        t0 = 1 / Vc;
        t = t0 * len;
      }

      str_t = t_to_str(t);
      document.getElementById('form-tl-t').value = str_t;
      VF = 100 / (Vc * t0);
      document.getElementById('form-tl-VF').value = float_to_string(VF, 3);

      C = t0 / Zo;
      L = t0 * Zo;
      str_C = C_to_str(C);
      str_L = L_to_str(L);
      document.getElementById('form-tl-C').value = str_C;
      document.getElementById('form-tl-L').value = str_L;

    }
    else {
      throw "invalid parameters";
    }
  }
  catch (err) {
    reportError(err);
  }
}

