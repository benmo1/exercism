<?php

/**
 * Optimised for readability
 *
 * @param string $text
 * @return bool
 */
function isValid(string $text): bool
{
    $filtered = array_reverse(str_split(str_replace(' ', '', $text)));

    if (($length = count($filtered)) <= 1) {
        return false;
    }

    for ($sum = 0, $i = 0; $i < $length; $i++) {
        if (!is_numeric($digit = $filtered[$i])) {
            return false;
        }
        $add = ($i % 2) ? 2 * $digit : $digit;
        $sum += ($add > 9) ? $add - 9 : $add;
    }

    return !($sum % 10);
}
