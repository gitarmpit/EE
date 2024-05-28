// Conversions start

let GThr = 0;
let MThr = 0;
let kThr = 0;
let baseThr = 0;
let mThr = 0;
let uThr = 0;
let nThr = 0;
let pThr = 0;
let fThr = 0;

let precision = 3;

function init_conversions() {
  GThr = set_threshold(1e12);
  MThr = set_threshold(1e9);
  kThr = set_threshold(1e6);
  baseThr = set_threshold(1e3);
  mThr = set_threshold(1);
  uThr = set_threshold(1e-3);
  nThr = set_threshold(1e-6);
  pThr = set_threshold(1e-9);
  fThr = set_threshold(1e-12);

}

function set_threshold(m) {
  return m * (1 - Math.pow(10, -(precision + 1)));
}


function string_to_float(str, negativeAllowed) {
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

function string_to_int(str) {
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
  else if (R < mThr) {
    R *= 1e3;
    units = "m";
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

const SECONDS_IN_A_MINUTE = 60;
const SECONDS_IN_AN_HOUR = 60 * SECONDS_IN_A_MINUTE;
const SECONDS_IN_A_DAY = 24 * SECONDS_IN_AN_HOUR;
const SECONDS_IN_A_MONTH = 30 * SECONDS_IN_A_DAY;
const SECONDS_IN_A_YEAR = 365 * SECONDS_IN_A_DAY;


function YMDH_to_Seconds(years, months, days, hours) {

  return (years * SECONDS_IN_A_YEAR) +
    (months * SECONDS_IN_A_MONTH) +
    (days * SECONDS_IN_A_DAY) +
    (hours * SECONDS_IN_AN_HOUR);
}

function seconds_to_YMDH(seconds) {
  let remainingSeconds = seconds;

  const years = Math.floor(remainingSeconds / SECONDS_IN_A_YEAR);
  remainingSeconds %= SECONDS_IN_A_YEAR;

  const months = Math.floor(remainingSeconds / SECONDS_IN_A_MONTH);
  remainingSeconds %= SECONDS_IN_A_MONTH;

  const days = Math.floor(remainingSeconds / SECONDS_IN_A_DAY);
  remainingSeconds %= SECONDS_IN_A_DAY;

  const hours = Math.floor(remainingSeconds / SECONDS_IN_AN_HOUR);

  return [years, months, days, hours];
}

// Conversions end

