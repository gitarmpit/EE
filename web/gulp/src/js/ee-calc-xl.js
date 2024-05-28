class EE_Xl extends EE_Calc {

  L_field = null;
  freq_field = null;
  Z_field = null;

  constructor() {
    super("form-Xl");
    this.L_field = new EE_Calc_L(this.form_name + "-L");
    this.freq_field = new EE_Calc_Freq(this.form_name + "-freq");
    this.Z_field = new EE_Calc_R(this.form_name + "-Xl");
    this.init();
  }

  clear() {
    this.L_field.clear();
    this.freq_field.clear();
    this.Z_field.clear();
  }

  calc(targetId) {
    try {
      let L = 0;
      let freq = 0;
      let Z = 0;
      let nparam = 0;

      if (!this.L_field.empty()) {
        L = this.L_field.getValue();
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
        if (L != 0 && freq != 0) {
          Z = 2 * Math.PI * freq * L;
          this.Z_field.setValue(Z);
        }
        else if (L != 0 && Z != 0) {
          freq = Z / (2 * Math.PI * L);
          this.freq_field.setValue(freq);
        }
        else {
          L = Z / (2 * Math.PI * freq);
          this.L_field.setValue(L);
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

