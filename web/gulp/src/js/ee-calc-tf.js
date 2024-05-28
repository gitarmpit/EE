class EE_tf extends EE_Calc {

  t = null;
  freq = null;

  constructor() {
    super("form-tf");
    this.t = new EE_Calc_Time(this.form_name + "-t");
    this.freq = new EE_Calc_Freq(this.form_name + "-f");
    this.init();
  }

  clear() {
    this.freq.clear();
    this.t.clear();
  }

  calc(targetId) {
    try {
      if (!this.freq.empty() && this.t.empty()) {
        this.t.setValue (1 / this.freq.getValue());
      }
      else if (this.freq.empty() && !this.t.empty()) {
        this.freq.setValue (1 / this.t.getValue());
      }
      else {
        throw "invalid input";
      }

    }
    catch (err) {
      reportError(err);
    }
  }


}

