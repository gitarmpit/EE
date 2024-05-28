class EE_Xc extends EE_Calc {

  C_field = null;
  freq_field = null;
  Z_field = null;

  constructor() {
    super("form-Xc");
    this.C_field = new EE_Calc_C(this.form_name + "-C");
    this.freq_field = new EE_Calc_Freq(this.form_name + "-freq");
    this.Z_field = new EE_Calc_R(this.form_name + "-Xc");
    this.init();
  }

  clear() {
    this.C_field.clear();
    this.freq_field.clear();
    this.Z_field.clear();
  }

  calc(targetId) {
    try {
      let C = 0;
      let freq = 0;
      let Z = 0;
      let nparam = 0;

      if (!this.C_field.empty()) {
        C = this.C_field.getValue();
        ++nparam;
      }

      if (!this.freq_field.empty()) {
        freq = this.freq_field.getValue();
        ++nparam;
      }

      if (!this.Z_field.empty()) {
        Z = this.Z_field.getValue();
        ++nparam;
      }

      if (nparam == 2) {
        if (C != 0 && freq != 0) {
          Z = 1 / (2 * Math.PI * freq * C);
          this.Z_field.setValue(Z);
        }
        else if (C != 0 && Z != 0) {
          freq = 1 / (2 * Math.PI * Z * C);
          this.freq_field.setValue(freq);
        }
        else {
          C = 1 / (2 * Math.PI * freq * Z);
          this.C_field.setValue(C);
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


}

