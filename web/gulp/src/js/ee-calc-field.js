// ee-calc-field.js start

class EE_Calc_Field {

  #elementId = '';

  constructor(elementId) {
    this.#elementId = elementId;
  }

  clear() {
    this.#getElementById().value = '';
  }

  empty() {
    return this.#getElementById().value === '';
  }
  
  // Set a string value directly without any conversions
  setStringValue(str) {
    this.#getElementById().value = str;
  }

  // Verbatim value from the field
  getStringValue() {
    return this.#getElementById().value;
  }

  // Convert numeric value to string followed by units
  // 0.001 =>  "1mA"
  setValue(value) {
    this.#getElementById().value = this._toString(value);
  }

  // Convert a string representation to a numeric value
  // "1mA" => 0.001
  getValue() {
    return this._toValue(this.#getElementById().value);
  }

  #getElementById() {
    return document.getElementById(this.#elementId);
  }

  /// Override in each class (C, R, etc)

  _toString(val) {
    return null;
  }

  _toValue(str) {
    return null;
  }
}

class EE_Calc_Float extends EE_Calc_Field {
  _toString(value) {
    return float_to_string(value);
  }
  _toValue(str) {
    return string_to_float (str);
  }
}

class EE_Calc_V extends EE_Calc_Field {
  _toString(value) {
    return V_to_str(value);
  }
  _toValue(str) {
    return str_to_V (str);
  }
}

class EE_Calc_I extends EE_Calc_Field {
  _toString(value) {
    return I_to_str(value);
  }
  _toValue(str) {
    return str_to_I (str);
  }
}

class EE_Calc_R extends EE_Calc_Field {
  _toString(value) {
    return R_to_str(value);
  }
  _toValue(str) {
    return str_to_R (str);
  }
}

class EE_Calc_P extends EE_Calc_Field {
  _toString(value) {
    return P_to_str(value);
  }
  _toValue(str) {
    return str_to_P (str);
  }
}

// e-calc-field.js  end


