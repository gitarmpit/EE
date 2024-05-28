// e-calc-ohms.js start


class EE_Ohms_Law extends EE_Calc {

  V_field = null;
  R_field = null;
  I_field = null;
  P_field = null;

  constructor() {
    super("form-ohm");
    this.V_field = new EE_Calc_V(this.form_name + "-V");
    this.R_field = new EE_Calc_R(this.form_name + "-R");
    this.I_field = new EE_Calc_I(this.form_name + "-I");
    this.P_field = new EE_Calc_P(this.form_name + "-P");
    this.init();
  }

  clear() {
    this.V_field.clear();
    this.R_field.clear();
    this.I_field.clear();
    this.P_field.clear();
  }

  calc() {
    try {
      let V = 0;
      let R = 0;
      let I = 0;
      let P = 0;
      let nparam = 0;

      if (!this.V_field.empty()) {
        V = this.V_field.getValue();
        ++nparam;
      }

      if (!this.R_field.empty()) {
        R = this.R_field.getValue();
        ++nparam;
      }

      if (!this.I_field.empty()) {
        I = this.I_field.getValue();
        ++nparam;
      }

      if (!this.P_field.empty()) {
        P = this.P_field.getValue();
        ++nparam;
      }

      if (nparam == 2) {
        if (V != 0 && R != 0) {
          I = V / R;
          P = I * V;
          this.I_field.setValue (I);
          this.P_field.setValue (P);
        }
        else if (V != 0 && I != 0) {
          R = V / I;
          P = V * I;
          this.R_field.setValue (R);
          this.P_field.setValue (P);
        }
        else if (I != 0 && R != 0) {
          V = I * R;
          P = V * I;
          this.V_field.setValue (V);
          this.P_field.setValue (P);
        }
        else if (P != 0 && R != 0) {
          V = Math.sqrt(P * R);
          I = V / R;
          this.V_field.setValue (V);
          this.I_field.setValue (I);
        }
        else if (P != 0 && I != 0) {
          V = P / I;
          R = V / I;
          this.V_field.setValue (V);
          this.R_field.setValue (R);
        }
        else if (P != 0 && V != 0) {
          R = V * V / P;
          I = V / R;
          this.R_field.setValue (R);
          this.I_field.setValue (I);
        }
        else {
          throw ("unexpected");
        }
  
      }
      else {
        throw ("wrong number of input fields");
      }

    }
    catch (err) {
      reportError(err);
    }
  }


}

// e-calc-ohms.js end

