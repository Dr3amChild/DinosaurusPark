class FormValidator {
    constructor(errorClass) {
        this.errorClass = errorClass;
    }

    validateInputs(inputs) {
        let result = true;
        for (let input of inputs) {
            const isValid = this.validateNumber(input.value, input.getAttribute("min"), input.getAttribute("max"));
            if (isValid) {
                input.classList.remove(this.errorClass);
            } else {
                input.classList.add(this.errorClass);
                $(input).tooltip({ title: input.getAttribute("message"), placement: "right" }).tooltip("show");
                result = false;
            }
        }
        return result;
    }

    validateNumber(value, min, max) {
        const number = Math.floor(Number(value));
        return number !== Infinity &&
               String(number) === value &&
               number > 0 &&
               number >= min &&
               number <= max;
    }
}