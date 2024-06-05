class EE_Calc_Field {

  elementId = '';

  _precision = null;

  constructor(elementId, precision) {
    this.elementId = elementId;
    if (precision != null) {
      this._precision = precision;
    }
  }

  clear() {
    this.getElementById().value = '';
  }

  empty() {
    return this.getElementById().value === '';
  }
  

  // Verbatim value from the field
  getStringValue() {
    return this.getElementById().value;
  }

  setStringValue(str) {
    this.getElementById().value = str;
  }

  // Convert numeric value to string followed by units
  // 0.001 =>  "1mA"
  setValue(value) {
    this.getElementById().value = this._toString(value);
  }

  // Convert a string representation to a numeric value
  // "1mA" => 0.001
  getValue() {
    if (!this.empty()) {
      return this._toValue(this.getElementById().value);
    }
    return 0;
  }

  getElementById() {
    return document.getElementById(this.elementId);
  }

  /// Override in each class (C, R, etc)

  _toString(val) {
    return null;
  }

  _toValue(str) {
    return null;
  }
}

class EE_Calc_Int extends EE_Calc_Field {
  _toString(value) {
    return value.toString();
  }
  _toValue(str) {
    return string_to_int (str);
  }
}

class EE_Calc_Float extends EE_Calc_Field {

  negativeAllowed = false;

  constructor(elementId, precision, negativeAllowed) {
    super (elementId, precision);
    if (negativeAllowed == null) {
      negativeAllowed = false;
    }
    this.negativeAllowed = negativeAllowed;
  }
  _toString(value) {
    return float_to_string(value, this._precision);
  }
  _toValue(str) {
    return string_to_float (str, this.negativeAllowed);
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

class EE_Calc_C extends EE_Calc_Field {
  _toString(value) {
    return C_to_str(value);
  }
  _toValue(str) {
    return str_to_C (str);
  }
}

class EE_Calc_L extends EE_Calc_Field {
  _toString(value) {
    return L_to_str(value);
  }
  _toValue(str) {
    return str_to_L (str);
  }
}

class EE_Calc_Freq extends EE_Calc_Field {
  _toString(value) {
    return freq_to_str(value);
  }
  _toValue(str) {
    return str_to_freq (str);
  }
}

class EE_Calc_Time extends EE_Calc_Field {
  _toString(value) {
    return t_to_str(value);
  }
  _toValue(str) {
    return str_to_t (str);
  }
}

class EE_Calc_Len extends EE_Calc_Field {
  _toString(value) {
    return len_to_str(value);
  }
  _toValue(str) {
    return str_to_len (str);
  }
}



