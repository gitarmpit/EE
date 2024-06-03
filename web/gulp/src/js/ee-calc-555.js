const E6 = [1.0, 1.5, 2.2, 3.3, 4.7, 6.8];
const E12 = [1, 1.2, 1.5, 1.8, 2.2, 2.7, 3.3, 3.9, 4.7, 5.6, 6.8, 8.2];
const E24 = [1, 1.1, 1.2, 1.3, 1.5, 1.6, 1.8, 2, 2.2, 2.4, 2.7, 3, 3.3, 3.6, 3.9, 4.3, 4.7, 5.1, 5.6, 6.2, 6.8, 7.5, 8.2, 9.1, 10];
let E_array = [];
let l2 = Math.log(2);

function round_off_c(C) {
  return Math.pow(10, Math.ceil(Math.log10(C) - 0));
}

function getEValue(value, array) {

  if (array == null) {
    array = E_array;
  }

  const magnitude = Math.pow(10, Math.floor(Math.log10(value)));
  const normalizedValue = value / magnitude;

  let closest = array[0];
  let minDifference = Math.abs(normalizedValue - array[0]);

  for (let i = 1; i < array.length; i++) {
    const difference = Math.abs(normalizedValue - array[i]);
    if (difference < minDifference) {
      closest = array[i];
      minDifference = difference;
    }
  }

  return closest * magnitude;
}

class EE_555 extends EE_Calc {

  R1_field = null;
  R2_field = null;
  C_field = null;
  dc_field = null;
  th_field = null;
  tl_field = null;
  f_field = null;

  R1 = 0;
  R2 = 0;
  C = 0;
  dc = 0;
  th = 0;
  tl = 0;
  f = 0;

  #min_DC = 50.05;

  constructor() {
    super("form-555");
    this.R1_field = new EE_Calc_R(this.form_name + "-R1");
    this.R2_field = new EE_Calc_R(this.form_name + "-R2");
    this.C_field = new EE_Calc_C(this.form_name + "-C");
    this.dc_field = new EE_Calc_Float(this.form_name + "-dc");
    this.th_field = new EE_Calc_Time(this.form_name + "-th");
    this.tl_field = new EE_Calc_Time(this.form_name + "-tl");
    this.f_field = new EE_Calc_Freq(this.form_name + "-f");

    this.init();
    let e = document.getElementById(this.form_name + "-dc");
    e.onblur = () => {
      this.#process_555_dc();
    }
  
    e = document.getElementById(this.form_name + "-f");
    e.onblur = () => {
      this.#process_555_f();
    }
  
  
    e = document.getElementById(this.form_name + "-th");
    e.onblur = () => {
      this.#process_555_th();
    }
  
    e = document.getElementById(this.form_name + "-tl");
    e.onblur = () => {
      this.#process_555_tl();
    }

    document.querySelectorAll('input[name="e"]').forEach(radio => {
      radio.addEventListener('change', (e) => {
        const value = e.target.id;
        if (value == "e-e6") {
          E_array = E6;
        }
        else if (value == "e-e12") {
          E_array = E12;
        }
        else if (value == "e-e24") {
          E_array = E24;
        }
        else {
          E_array = [];
        }
      });
    });

    const radios = document.querySelectorAll('input[name="e"]');
    radios.forEach(radio => {
      if (radio.id === "e-exact") {
        radio.checked = true;
      }
    });

  }

  clear() {
    this.R1_field.clear();
    this.R2_field.clear();
    this.C_field.clear();
    this.dc_field.clear();
    this.th_field.clear();
    this.tl_field.clear();
    this.f_field.clear();
    this.#clear_tmp();
  }

  #clear_tmp() {
    this.R1 = 0;
    this.R2 = 0;
    this.C = 0;
    this.dc = 0;
    this.th = 0;
    this.tl = 0;
    this.f = 0;
  }

  #process_555_f() {
    this.#clear_tmp();
    try {
      
      if (!this.f_field.empty()) {
        this.f = this.f_field.getValue();
        if (this.dc_field.empty()) {
          this.dc = 50.5;
          this.dc_field.setValue(this.dc);
        }
        else {
          this.dc = this.dc_field.getValue();
        }
      }

      if (!this.th_field.empty()) {
        this.th = this.th_field.getValue();
      }
      if (!this.tl_field.empty()) {
        this.tl = this.tl_field.getValue();
      }

    }
    catch {
      this.f_field.clear();
      this.f = 0;
    }

    if (this.f > 0) {
      let t100 = 1 / this.f;
      this.th = t100 * this.dc / 100;
      this.tl = t100 - this.th;
      this.th_field.setValue(this.th);
      this.tl_field.setValue(this.tl);
    }
    else if (this.th > 0 && this.tl > 0) {
      this.f = 1 / (this.th + this.tl);
      this.f_field.setValue(this.f);
    }
  
  }
  
  #process_555_dc() {

    this.#clear_tmp();

    try {

      if (!this.dc_field.empty()) {
        this.dc = this.dc_field.getValue();
        if (this.dc < this.#min_DC) {
          this.dc = this.#min_DC;
          this.dc_field.setValue(this.dc);
        }
        else if (this.dc > 99) {
          this.dc = 99;
          this.dc_field.setValue(this.dc);
        }
      }

      if (!this.th_field.empty()) {
        this.th = this.th_field.getValue();
      }

      if (!this.tl_field.empty()) {
        this.tl = this.tl_field.getValue();
      }
  
    }
    catch {
      this.dc = 0;
      this.dc_field.clear();
    }

    if (this.dc > 0) {
        
      if (this.th > 0 && this.tl == 0) {
        this.#set_tl_f_from_dc_th ();
      }
      else if (this.th == 0 && this.tl > 0) {
        this.#set_th_f_from_dc_tl ();
      }
      else if (this.th > 0 && this.tl > 0) {
        let t100 = this.th +this.tl;
        this.th = t100 * this.dc / 100;
        this.tl = t100 - this.th;
        this.th_field.setValue(this.th);
        this.tl_field.setValue(this.tl);
        this.f = 1 / (this.th + this.tl);
        this.f_field.setValue(this.f);
      }
    }
    else if (this.th > 0 && this.tl > 0) {
      this.dc = this.th / (this.th + this.tl) * 100;
      this.dc_field.setValue(this.dc);
    }
  
  }
  
  #set_tl_f_from_dc_th () {
    let t100 = this.th * 100 / this.dc;
    this.tl = t100 - this.th;
    this.tl_field.setValue(this.tl);
    this.f = 1 / t100;
    this.f_field.setValue(this.f);
  }

  #set_th_f_from_dc_tl () {
    let t100 = this.tl * 100 / (100 - this.dc);
    this.th = t100 - this.tl;
    this.th_field.setValue(this.th);
    this.f = 1 / t100;
    this.f_field.setValue(this.f);
  }

  #set_f_dc_from_th_tl () {
    this.f = 1 / (this.th + this.tl);
    this.f_field.setValue(this.f);
    this.dc = this.th / (this.th + this.tl) * 100;
    this.dc_field.setValue(this.dc);
  }

  #process_555_th() {

    this.#clear_tmp();

    try {
  
      if (!this.th_field.empty()) {
        this.th = this.th_field.getValue();
      }

      if (!this.tl_field.empty()) {
        this.tl = this.tl_field.getValue();
      }

      if (!this.dc_field.empty()) {
        this.dc = this.dc_field.getValue();
      }
  
      if (!this.f_field.empty()) {
        this.f = this.f_field.getValue();
      }
    }
    catch {
      this.th = 0;
      this.th_field.clear();
    }

    if (this.th > 0 && this.tl > 0) {
  
      if (this.tl >= this.th) {
        this.th = this.tl * 1.0205;
        this.th_field.setValue(this.th);
      }

      this.#set_f_dc_from_th_tl();
    } 
    else if (this.th > 0 && this.tl == 0 && this.dc > 0) {
      this.#set_tl_f_from_dc_th ();
    }
    else if (this.th == 0 && this.tl > 0 && this.f > 0) {
      let t100 = 1 / this.f;
      this.th = t100 - this.tl;
      this.th_field.setValue(this.th);
    }
  
  }
  
  #process_555_tl() {

    this.#clear_tmp();

    try {
      
      if (!this.th_field.empty()) {
        this.th = this.th_field.getValue();
      }

      if (!this.tl_field.empty()) {
        this.tl = this.tl_field.getValue();
      }

      if (!this.dc_field.empty()) {
        this.dc = this.dc_field.getValue();
      }
  
      if (!this.f_field.empty()) {
        this.f = this.f_field.getValue();
      }
    }
    catch {
      this.tl = 0;
      this.tl_field.clear();
    }
  
    if (this.th > 0 && this.tl > 0) {
  
      if (this.th <= this.tl) {
        this.tl = this.th * 0.98;
        this.tl_field.setValue(this.tl);
      }

      this.#set_f_dc_from_th_tl();
    }
    else if (this.th == 0 && this.tl > 0 && this.dc > 0) {
      this.#set_th_f_from_dc_tl();
    }
    else if (this.th > 0 && this.tl == 0 && this.f > 0 ) {
      let t100 = 1 / this.f;
      this.tl = t100 - this.th;
      this.tl_field.setValue(this.tl);
    }
    else if (this.tl == 0 && this.f == 0 && this.th > 0 && this.dc > 0) {
      this.#set_tl_f_from_dc_th();
    }

  }
  
  
  #calc_555_timing() {
  
    this.th = l2 * (this.R1 + this.R2) * this.C;
    this.tl = l2 * this.R2 * this.C;
    this.dc = this.th / (this.th + this.tl) * 100;
    this.f = 1 / (this.th + this.tl);

    this.f_field.setValue (this.f);
    this.th_field.setValue (this.th);
    this.tl_field.setValue (this.tl);
    this.dc_field.setValue (this.dc);
  }
  
  #calc_R1_R2() {
    let r2c = this.tl / l2;
    let r1c = this.th / l2 - r2c;
    if (this.C == 0) {
      this.C = (1e-5 / this.f) / 1.5;
      if (this.C < 1e-10) {
        this.C = 1e-10;
      }
    }
  
    this.R1 = r1c / this.C;
    this.R2 = r2c / this.C;
  }
  
  calc(targetId) {

  
    let t_cnt = 0;
    let timing_set = false;
  
    this.#clear_tmp();

    try {
  
      if (targetId == this.form_name + "-th") {
        this.#process_555_th();
      }
      else if (targetId == this.form_name + "-tl") {
        this.#process_555_tl();
      }
      else if (targetId == this.form_name + "-dc") {
        this.#process_555_dc();
      }
      else if (targetId == this.form_name + "-f") {
        this.#process_555_f();
      }
  
      if (!this.R1_field.empty()) {
        this.R1 = this.R1_field.getValue();
      }
      if (!this.R2_field.empty()) {
        this.R2 = this.R2_field.getValue();
      }
      if (!this.C_field.empty()) {
        this.C = this.C_field.getValue();
      }

      if (!this.dc_field.empty()) {
        this.dc = this.dc_field.getValue();
        if (this.dc < 50) {
          this.dc = 50;
          this.dc_field.setValue(this.dc);
        }
        if (this.dc > 99) {
          this.dc = 99;
          this.dc_field.setValue(this.dc);
        }
        ++t_cnt;
      }

      if (!this.th_field.empty()) {
        this.th = this.th_field.getValue();
        ++t_cnt;
      }

      if (!this.tl_field.empty()) {
        this.tl = this.tl_field.getValue();
        ++t_cnt;
      }

      if (!this.f_field.empty()) {
        this.f = this.f_field.getValue();
        ++t_cnt;
      }
  
      if (t_cnt == 4) {
        timing_set = true;
      }

      if ((targetId == this.form_name + "-R1" || 
           targetId == this.form_name + "-R1" || 
           targetId == this.form_name + "-C") && this.R1 != 0 && this.R2 != 0 && this.C != 0) {
        timing_set = false;
      }
  
      if (this.R1 != 0 && this.R2 != 0 && this.C != 0 && !timing_set) {
        this.#calc_555_timing ();
      }
      else if (timing_set && this.R1 == 0 && this.R2 == 0) {
        
        this.#calc_R1_R2();
  
        if (E_array.length) {
          console.log(E_array.length);
          console.log ("old C:" + C_to_str (this.C));
          console.log ("old R1:" + R_to_str (this.R1));
          console.log ("old R2:" + R_to_str (this.R2));
  
          this.R1 = getEValue (this.R1);
          this.R2 = getEValue (this.R2);

          let r2c = this.tl / l2;
          this.C = r2c / this.R2;
          console.log ("corrected old C:" + C_to_str (this.C));

          this.C = getEValue (this.C);
  
          console.log ("new C:" + C_to_str (this.C));
          console.log ("new R1:" + R_to_str (this.R1));
          console.log ("new R2:" + R_to_str (this.R2));
  
        }
        else {
          // this.C = getEValue(this.C, E6);
        }
  
        this.#calc_555_timing ();

        this.R1_field.setValue(this.R1);
        this.R2_field.setValue(this.R2);
        this.C_field.setValue(this.C);
      }
      else if (timing_set && this.C != 0 && this.R1 != 0 && this.R2 == 0) {

        if (E_array.length) {
          this.R1 = getEValue(this.R1);
          this.C = getEValue(this.C);
          this.R1_field.setValue(this.R1);
          this.C_field.setValue(this.C);
        }
        
        this.R2 = this.tl / l2 / this.C;
        if (E_array.length) {
          this.R2 = getEValue(this.R2);
        }
        this.#calc_555_timing();

        this.R2_field.setValue(this.R2);
      }
      else if (timing_set && this.C != 0 && this.R1 == 0 && this.R2 != 0) {

        if (E_array.length) {
          this.R2 = getEValue(this.R2);
          this.R2_field.setValue(this.R2);
          this.C = getEValue(this.C);
          this.C_field.setValue(this.C);
        }

        this.tl = l2 * this.R2 * this.C;

        let t100 = this.tl * 100 / (100 - this.dc);
        this.th = t100 - this.tl;

        if (this.th <= this.tl) {
          throw ("th <= tl");
        }

        this.R1 = this.th / l2 / this.C - this.R2;

        if (E_array.length) {
          this.R1 = getEValue(this.R1);
        }
        this.#calc_555_timing();
        this.R1_field.setValue(this.R1);
  
      }
      else if (timing_set && this.C == 0 && this.R1 != 0 && this.R2 != 0) {

        if (E_array.length) {
          this.R1 = getEValue(this.R1);
          this.R1_field.setValue(this.R1);
          this.R2 = getEValue(this.R2);
          this.R2_field.setValue(this.R2);
       }

        let r2c = this.tl / l2;
        this.C = r2c / this.R2;
        if (E_array.length) {
          this.C = getEValue(this.C);
        }
        this.#calc_555_timing ();
        this.C_field.setValue(this.C);
      }
      else {
        throw "invalid parameters";
      }
  
    }
    catch (err) {
      console.log(err);
      reportError(err);
    }
  }

}
