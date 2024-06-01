let max_AWG = 40;
let max_wire_d = 0.1;
let AWG_old = -1;
const ro_cu_25C = 1.712e-8

function wire_process_AWG(AWG_field, d_field) {

  if (!AWG_field.empty()) {
    let AWG = AWG_field.getValue();
    if (AWG > max_AWG) {
      AWG = max_AWG;
      AWG_field.setValue(AWG);
    }

    if (AWG != AWG_old || d_field.empty()) {
      set_d_from_AWG(AWG, d_field);
    }

    AWG_old = AWG;
  }

}

function wire_process_d(d_field, AWG_field) {

  try {
    if (!d_field.empty()) {
      d = d_field.getValue();
      if (d > max_wire_d) {
        d = max_wire_d;
        d_field.setStringValue("100mm");
      }
      let AWG = set_AWG_from_d(d, AWG_field);
      AWG_old = AWG;
    }
    else {
      if (!AWG_field.empty()) {
        set_d_from_AWG(AWG_field.getValue(), d_field);
      }
    }
  }
  catch {
    if (!AWG_field.empty()) {
      set_d_from_AWG(AWG_field.getValue(), d_field);
    }
  }

}

function set_d_from_AWG(AWG, d_field) {
  let d = Math.pow(Math.E, (2.1104 - 0.11594 * AWG));
  let str_d = float_to_string(d, 3) + "mm";
  d_field.setStringValue (str_d);
  return d;
}

function set_AWG_from_d(d, AWG_field) {
  let AWG = (2.1104 - Math.log(d * 1000)) / 0.11594;
  AWG = Math.round(AWG);
  if (AWG >= 0 && AWG <= max_AWG) {
    AWG_field.setValue(AWG);
  }
  else {
    AWG_field.clear();
    AWG = -1;
  }
  return AWG;
}



class EE_WireRes extends EE_Calc {

  AWG = null;
  d = null;
  len = null;
  t = null;
  R = null;

  constructor() {
    super("form-wres");
    this.AWG = new EE_Calc_Int(this.form_name + "-AWG");
    this.d = new EE_Calc_Len(this.form_name + "-d");
    this.len = new EE_Calc_Len(this.form_name + "-len");
    this.t = new EE_Calc_Float(this.form_name + "-t");
    this.R = new EE_Calc_R(this.form_name + "-R");

    this.init();
    let e = document.getElementById(this.form_name + "-AWG");
    e.onblur = () => {
      wire_process_AWG(this.AWG, this.d);
    }
  
    e = document.getElementById(this.form_name + "-d");
    e.onblur = () => {
      wire_process_d(this.d, this.AWG);
    }
  
  }

  clear() {
    this.AWG.clear();
    this.d.clear();
    this.len.clear();
    this.t.setValue (25);
    this.R.clear();
  }


  calc(targetId) {
    let AWG = -1;
    let d = 0;
    let len = 0;
    let R = 0;
    let t = 0;
    let ro = ro_cu_25C;
    let A = 0;

    try {

      if (!this.AWG.empty()) {
        AWG = this.AWG.getValue();
        if (AWG > max_AWG) {
          AWG = max_AWG;
          this.AWG.setValue(AWG);
        }
      }

      if (!this.d.empty()) {
        d = this.d.getValue();
        if (d > max_wire_d) {
          d = max_wire_d;
          this.d.setStringValue("100mm");
        }
      }

      if (!this.len.empty()) {
        len = this.len.getValue();
      }

      if (!this.t.empty()) {
        t = this.t.getValue();
        if (t < -150) {
          t = -150;
        }
        else if (t > 250) {
          t = 250;
        }
        this.t.setValue(t);
        ro = ro_cu_25C * (1 + .003987 * (t - 25));
      }

      if (!this.R.empty()) {
        R = this.R.getValue();
      }

      if (d == 0 && AWG != -1) {
        d = set_d_from_AWG(AWG, this.d);
        d /= 1000;
      }

      if (d != 0) {
        A = Math.PI * d * d / 4;
      }

      if (d != 0 && len != 0 && R == 0 && t != 0) {
        R = ro * len / A;
        this.R.setValue(R);
      }
      else if (d != 0 && len == 0 && R != 0 && t != 0) {
        len = R * A / ro;
        this.len.setValue(len);
      }
      else if (d == 0 && len != 0 && R != 0 && t != 0) {
        A = ro * len / R;
        d = Math.sqrt(4 * A / Math.PI);
        let str_d = float_to_string(d * 1000, 3) + "mm";
        this.d.setStringValue(str_d);
        AWG = set_AWG_from_d(d, this.AWG);
      }
      else if (d != 0 && len != 0 && R != 0 && t == 0) {
        ro = R * A / len;
        t = (ro / ro_cu_25C - 1) / .003987 + 25;
        if (t < -150 || t > 250) {
          throw "invalid range";
        }
        this.t.setValue (t);
      }
      else {
        throw "invalid parameters";
      }
    }
    catch (err) {
      reportError(err);
    }
  }

}

class EE_Vdrop extends EE_Calc {

  AWG = null;
  d = null;
  len = null;
  t = null;
  V = null;
  I = null;

  constructor() {
    super("form-vdrop");
    this.AWG = new EE_Calc_Int(this.form_name + "-AWG");
    this.d = new EE_Calc_Len(this.form_name + "-d");
    this.len = new EE_Calc_Len(this.form_name + "-len");
    this.t = new EE_Calc_Float(this.form_name + "-t");
    this.V = new EE_Calc_V(this.form_name + "-V");
    this.I = new EE_Calc_I(this.form_name + "-I");

    this.init();
    let e = document.getElementById(this.form_name + "-AWG");
    e.onblur = () => {
      wire_process_AWG(this.AWG, this.d);
    }
  
    e = document.getElementById(this.form_name + "-d");
    e.onblur = () => {
      wire_process_d(this.d, this.AWG);
    }
  
  }

  clear() {
    this.AWG.clear();
    this.d.clear();
    this.len.clear();
    this.t.setValue (25);
    this.V.clear();
    this.I.clear();
  }


  calc(targetId) {
    let AWG = -1;
    let d = 0;
    let len = 0;
    let V = 0;
    let I = 0;
    let t = 0;
    let ro = ro_cu_25C;
    let A = 0;
    let R = 0;

    try {

      if (!this.AWG.empty()) {
        AWG = this.AWG.getValue();
        if (AWG > max_AWG) {
          AWG = max_AWG;
          this.AWG.setValue(AWG);
        }
      }

      if (!this.d.empty()) {
        d = this.d.getValue();
        if (d > max_wire_d) {
          d = max_wire_d;
          this.d.setStringValue("100mm");
        }
      }

      if (!this.len.empty()) {
        len = this.len.getValue();
      }

      if (!this.t.empty()) {
        t = this.t.getValue();
        if (t < -150) {
          t = -150;
        }
        else if (t > 250) {
          t = 250;
        }
        this.t.setValue(t);
        ro = ro_cu_25C * (1 + .003987 * (t - 25));
      }

      if (!this.V.empty()) {
        V = this.V.getValue();
      }

      if (!this.I.empty()) {
        I = this.I.getValue();
      }

      if (d == 0 && AWG != -1) {
        d = set_d_from_AWG(AWG, this.d);
        d /= 1000;
      }

      if (d != 0) {
        A = Math.PI * d * d / 4;
      }

      if (d != 0 && len != 0 && I != 0 && t != 0 && V == 0) {
        R = ro * len / A;
        V = I * R;
        this.V.setValue(V);
      }
      else if (d != 0 && len == 0 && I != 0 && t != 0 && V != 0) {
        R = V / I;
        len = R * A / ro;
        this.len.setValue(len);
      }
      else if (d == 0 && len != 0 && I != 0 && t != 0 && V != 0) {
        R = V / I;
        A = ro * len / R;
        d = Math.sqrt(4 * A / Math.PI);
        let str_d = float_to_string(d * 1000) + "mm";
        this.d.setStringValue(str_d);
        set_AWG_from_d (d, this.AWG);
      }
      else if (d != 0 && len != 0 && I != 0 && t == 0 && V != 0) {
        R = V / I;
        ro = R * A / len;
        t = (ro / ro_cu_25C - 1) / .003987 + 25;
        if (t < -150 || t > 250) {
          throw "invalid range";
        }
        this.t.setValue (t);
      }
      else if (d != 0 && len != 0 && I == 0 && t != 0 && V != 0) {
        R = ro * len / A;
        I = V / R;
        this.I.setValue(I);
      }
      else {
        throw "invalid parameters";
      }
    }
    catch (err) {
      reportError(err);
    }
  }

}
