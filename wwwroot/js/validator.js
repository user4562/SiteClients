
//// form: inputMask init

//const inputTel = document.querySelector("input[type='tel']");
//const inputMask = new Inputmask('+7 (999)-999-99-99');

//const inputEmail = document.querySelector("input[type='email']");

//inputMask.mask(inputTel);

//// form: validator init

//const validator = new JustValidate('.form', {
//    errorFieldCssClass: 'input--invalid',
//    errorLabelCssClass: 'warning-label',
//    lockForm: false,
//});

//validator.addField('#firstName', [
//    {
//        rule: 'required',
//        errorMessage: 'Вы не ввели имя',
//    },
//    {
//        rule: 'minLength',
//        value: 3,
//        errorMessage: 'Имя слишком короткое'
//    },
//    {
//        rule: 'maxLength',
//        value: 50,
//        errorMessage: 'Имя слишком длинное'
//    },
//]).addField('#lastName', [
//    {
//        rule: 'required',
//        errorMessage: 'Вы не ввели фамилию',
//    },
//    {
//        rule: 'minLength',
//        value: 3,
//        errorMessage: 'Фамилия слишком короткая'
//    },
//    {
//        rule: 'maxLength',
//        value: 50,
//        errorMessage: 'Фамилия слишком длинная'
//    },
//]).addField('#birthDate', [
//    {
//        rule: 'required',
//        errorMessage: 'Вы не ввели дату рождения',
//    },
//]).addField('#phone', [
//    {
//        rule: 'required',
//        errorMessage: 'Вы не ввели телефон',
//    },
//    {
//        validator: (name, value) => {
//            const phone = inputTel.inputmask.unmaskedvalue();
//            return phone.length === 10;
//        },
//        errorMessage: 'Недопустимый формат',
//    },
//]).addField('#email', [
//    {
//        rule: 'required',
//        errorMessage: 'Вы не ввели email',
//    },
//    {
//        validator: (name, value) => {
//            const validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
//            return inputEmail.value.match(validRegex) != null;
//        },
//        errorMessage: 'Недопустимый формат',
//    }
//]);
