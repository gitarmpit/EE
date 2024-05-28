//  Frequency / Wavelength converter

class EE_fw extends EE_Calc {

  l = null;
  freq = null;
  c = 3e+8;

  constructor() {
    super("form-fw");
    this.l = new EE_Calc_Len(this.form_name + "-wl");
    this.freq = new EE_Calc_Freq(this.form_name + "-f");
    this.init();
  }

  clear() {
    this.freq.clear();
    this.l.clear();
  }

  calc(targetId) {
    try {

      let f = 0;
      let wl = 0;
  
      if (!this.freq.empty()) {
        f = this.freq.getValue();
      }

      if (!this.l.empty()) {
        wl = this.l.getValue();
      }

      if (targetId == this.form_name + "-wl" && wl != 0) {
        f = 0;
      }
      else if (targetId == this.form_name + "-f" && f != 0) {
        wl = 0;
      }
      
      if (f != 0 && wl == 0) {
        wl = this.c / f;
        this.l.setValue(wl);
      }
      else if (f == 0 && wl != 0) {
        f = this.c / wl;
        if (f >= 1) {
          this.freq.setValue(f);
        }
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

