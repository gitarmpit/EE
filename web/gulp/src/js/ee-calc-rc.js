class EE_RC_Cutoff_Freq extends EE_Calc {

  C = null;
  freq = null;
  R = null;
  t = null;


  constructor() {
    super("form-RC");
    this.C = new EE_Calc_C(this.form_name + "-C");
    this.freq = new EE_Calc_Freq(this.form_name + "-freq");
    this.R = new EE_Calc_R(this.form_name + "-R");
    this.t = new EE_Calc_Time(this.form_name + "-t");
    this.init();
    let e = document.getElementById(this.form_name + "-freq");
    e.onblur = () => {
      this.process_blur_freq();
    }
    e = document.getElementById(this.form_name + "-t");
    e.onblur = () => {
      this.process_blur_t();
    }
  
  }

  clear() {
    this.C.clear();
    this.freq.clear();
    this.R.clear();
    this.t.clear();
  }

  process_blur_freq() {
    if (!this.freq.empty()) {
      this.freq.getValue();
      this.calc_t_from_freq();
    }
    else {
      this.t.clear();
    }
  }

  process_blur_t() {
    if (!this.t.empty()) {
      this.calc_freq_from_t();
    }
    else {
      this.freq.clear();
    }
  }

  calc_t_from_freq() {
    this.t.setValue(1 / (2 * Math.PI * this.freq.getValue()));
  }

  calc_freq_from_t() {
    this.freq.setValue(1 / (2 * Math.PI * this.t.getValue()));
  }
  
  
  calc(targetId) {
    try {

      let tf_set = false;

      if (!this.t.empty() && this.freq.empty()) {
        this.calc_freq_from_t();
      }

      if (this.t.empty() && !this.freq.empty()) {
        this.calc_t_from_freq();
      }

      if (!this.t.empty() && !this.freq.empty()) {
        tf_set = true;
      }

      if (tf_set && !this.C.empty() && this.R.empty()) {
        this.R.setValue(1 / (2 * Math.PI * this.freq.getValue() * this.C.getValue()));
      }
      else if (tf_set && this.C.empty() && !this.R.empty()) {
        this.C.setValue(1 / (2 * Math.PI * this.freq.getValue() * this.R.getValue()));
      }
      else if (!tf_set && !this.C.empty() && !this.R.empty()) {
        this.t.setValue(this.R.getValue() * this.C.getValue());
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

