class EE_Vdiv extends EE_Calc {

  Vin_field = null;
  Vout_field = null;
  R1_field = null;
  R2_field = null;

  // r/o
  I_field = null;
  P1_field = null;
  P2_field = null;

  constructor() {
    super("form-vdiv");
    this.Vin_field = new EE_Calc_V(this.form_name + "-Vin");
    this.Vout_field = new EE_Calc_V(this.form_name + "-Vout");
    this.R1_field = new EE_Calc_R(this.form_name + "-R1");
    this.R2_field = new EE_Calc_R(this.form_name + "-R2");

    this.I_field = new EE_Calc_I(this.form_name + "-I");
    this.P1_field = new EE_Calc_P(this.form_name + "-P-R1");
    this.P2_field = new EE_Calc_P(this.form_name + "-P-R2");

    this.init();
  }

  clear() {
    this.Vin_field.clear();
    this.Vout_field.clear();
    this.R1_field.clear();
    this.R2_field.clear();

    this.I_field.clear();
    this.P1_field.clear();
    this.P2_field.clear();

  }

  calc(targetId) {
    try {
      let Vin = 0;
      let Vout = 0;
      let R1 = 0;
      let R2 = 0;
      let cnt = 0;

      if (!this.Vin_field.empty()) {
        Vin = this.Vin_field.getValue();
        ++cnt;
      }

      if (!this.Vout_field.empty()) {
        Vout = this.Vout_field.getValue();
        ++cnt;
      }

      if (!this.R1_field.empty()) {
        R1 = this.R1_field.getValue();
        ++cnt;
      }

      if (!this.R2_field.empty()) {
        R2 = this.R2_field.getValue();
        ++cnt;
      }

      if (Vin != 0 && Vout != 0 && Vout >= Vin) {
        throw "invalid input";
      }
  
      if (cnt == 2 && R1 != 0 && R2 != 0) {
        cnt = 3;
        Vin = 1;
        this.Vin_field.setValue (Vin);
      }
      else if (cnt == 2 && Vin != 0 && Vout != 0) {
        cnt = 3;
        R2 = 1000;
        this.R2_field.setValue (R2);
      }
  
      if (cnt == 3) {
  
        if (Vin != 0 && R1 != 0 && R2 != 0) {
          Vout = Vin * R2 / (R1 + R2);
          this.Vout_field.setValue (Vout);
        }
        else if (Vout != 0 && R1 != 0 && R2 != 0) {
          Vin = Vout * (R1 + R2) / R2;
          this.Vin_field.setValue (Vin);
        }
        else if (Vin != 0 && R1 != 0 && Vout != 0) {
          R2 = R1 / (Vin / Vout - 1);
          this.R2_field.setValue (R2);
        }
        else if (Vin != 0 && R2 != 0 && Vout != 0) {
          R1 = R2 * (Vin / Vout - 1);
          this.R1_field.setValue (R1);
        }
        else {
          throw "invalid parameters"
        }
  
        let I = Vin / (R1 + R2);
        this.I_field.setValue(I);

        let P1 = I * I * R1;
        this.P1_field.setValue(P1);

        let P2 = I * I * R2;
        let P2_field = new EE_Calc_P(this.form_name + "-P-R2");
        P2_field.setValue(P2);

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
