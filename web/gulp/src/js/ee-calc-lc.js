class EE_LC_LPF extends EE_Calc {

  C = null;
  freq = null;
  L = null;


  constructor() {
    super("form-LC");
    this.C = new EE_Calc_C(this.form_name + "-C");
    this.freq = new EE_Calc_Freq(this.form_name + "-freq");
    this.L = new EE_Calc_L(this.form_name + "-L");
    this.init();
  }

  clear() {
    this.C.clear();
    this.freq.clear();
    this.L.clear();
  }
  
  calc(targetId) {
    try {

      if (!this.freq.empty() && !this.C.empty() && this.L.empty()) {
        this.L.setValue(1 / (this.C.getValue() * Math.pow(2 * Math.PI * this.freq.getValue(),2) ) );
      }
      else if (!this.freq.empty() && this.C.empty() && !this.L.empty()) {
        this.C.setValue(1 / (this.L.getValue() * Math.pow(2 * Math.PI * this.freq.getValue(),2) ) );
      }
      else if (this.freq.empty() && !this.C.empty() && !this.L.empty()) {
        this.freq.setValue(1/ (2 * Math.PI * Math.sqrt(this.L.getValue() * this.C.getValue())) );
        this.calc_freq_from_t();
      }
      else {
        throw "invalid input"
      }
  
    }
    catch (err) {
      reportError(err);
    }
  }


}

